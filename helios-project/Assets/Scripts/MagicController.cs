using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public static MagicController instance;

    public bool casting;
    private float castTimeCounter;

    private Animator myAnimator;
    private Rigidbody2D myRigidbody;

    public GameObject activeSpell;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CharStats.instance.currentMP >= activeSpell.GetComponent<Spell>().manaCost) { 
            if (Input.GetKeyDown(KeyCode.R))
            {
                castTimeCounter = activeSpell.GetComponent<Spell>().castTime;
                casting = true;
                myRigidbody.velocity = Vector2.zero;
                myAnimator.SetBool("casting", true);

                var clone = (GameObject)Instantiate(activeSpell, PlayerController.instance.gameObject.transform.position + new Vector3(PlayerController.instance.lastMove.x * activeSpell.GetComponent<Spell>().spellRange, PlayerController.instance.lastMove.y * activeSpell.GetComponent<Spell>().spellRange, 0f), Quaternion.Euler(Vector3.zero));

                CharStats.instance.currentMP -= activeSpell.GetComponent<Spell>().manaCost;
            }
        }
        if (castTimeCounter > 0)
        {
            castTimeCounter -= Time.deltaTime;
        }

        if (castTimeCounter <= 0)
        {
            casting = false;
            myAnimator.SetBool("casting", false);
        }
    }
}
