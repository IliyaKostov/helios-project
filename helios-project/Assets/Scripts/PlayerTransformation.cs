using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{

    public GameObject Human;
    public GameObject Transformation;

    private Animator humanAnimator;
    private Rigidbody2D humanRigidbody;

    private PlayerController humanController;

    private int ShiftNum;

    public float transformTime;
    public float transformTimeCounter;
    public bool transforming;
    public bool transformingComplete;

    
    // Start is called before the first frame update
    void Start()
    {
        Human.SetActive(true);
        Transformation.SetActive(false);
        ShiftNum = 1;

        transformTimeCounter = transformTime;

        humanAnimator = Human.GetComponent<Animator>();
        humanRigidbody = Human.GetComponent<Rigidbody2D>();
        humanController = Human.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.T) && ShiftNum == 1) || transforming)
        {
            humanController.canMove = false;
            transforming = true;
            humanRigidbody.velocity = Vector2.zero;
            humanAnimator.SetBool("transforming", true);
         
            if (transformTimeCounter > 0)
            {
                transformTimeCounter -= Time.deltaTime;
            }

            if (transformTimeCounter <= 0)
            {
                transforming = false;
                humanAnimator.SetBool("transforming", false);
                transformingComplete = true;
            }
            if (transformingComplete)
            {
                Human.SetActive(false);
                Transformation.SetActive(true);
                ShiftNum = 2;
                Transformation.transform.position = Human.transform.position;
                Transformation.transform.rotation = Human.transform.rotation;

                transformingComplete = false;
                transformTimeCounter = transformTime;

                humanController.canMove = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.T) && ShiftNum == 2)
        {
            Human.SetActive(true);
            Transformation.SetActive(false);
            ShiftNum = 1;
            Human.transform.position = Transformation.transform.position;
            Human.transform.rotation = Transformation.transform.rotation;
        }
    }
}
