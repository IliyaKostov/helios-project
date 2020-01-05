using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;

    private bool playerMoving;
    public Vector2 lastMove;
    public bool canMove;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public bool defending;
    public float defendTime;
    private float defendTimeCounter;

    //public bool casting;
    //public float castTime;
    //private float castTimeCounter;

    public bool rolling;
    public float rollTime;
    public float rollTimeCounter;
    public float rollSpeed;

    private PlayerHealthManager thePHM;

    private Animator myAnimator;

    private Rigidbody2D myRigidbody;
    private Vector3 change;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        thePHM = GetComponent<PlayerHealthManager>();

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        if (!attacking && !defending && !rolling && !MagicController.instance.casting) 
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                // transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                // transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown("joystick button 0"))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                myAnimator.SetBool("attacking", true);
            }
            
            if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown("joystick button 2"))
            {
                defendTimeCounter = defendTime;
                defending = true;
                myRigidbody.velocity = Vector2.zero;
                myAnimator.SetBool("defending", true);
            }

            /*if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown("joystick button 3"))
            {
                castTimeCounter = castTime;
                casting = true;
                myRigidbody.velocity = Vector2.zero;
                myAnimator.SetBool("casting", true);
            }*/


            if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown("joystick button 1") || rolling)
            {
                rollTimeCounter = rollTime;
                rolling = true;
                myRigidbody.velocity = new Vector2(lastMove.x * -rollSpeed, lastMove.y * -rollSpeed);
                myAnimator.SetBool("rolling", true);
                if (rollTimeCounter <= 0)
                {
                    myRigidbody.velocity = Vector2.zero;
                }
            }
            


            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }

        }
        
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            myAnimator.SetBool("attacking", false);
        }
        
        if (defendTimeCounter > 0)
        {
            defendTimeCounter -= Time.deltaTime;
        }

        if (defendTimeCounter <= 0)
        {
            defending = false;
            myAnimator.SetBool("defending", false);
        }

        if (rollTimeCounter > 0)
        {
            rollTimeCounter -= Time.deltaTime;
        }

        if (rollTimeCounter <= 0)
        {
            rolling = false;
            myAnimator.SetBool("rolling", false);
        }

        /*if (castTimeCounter > 0)
        {
            castTimeCounter -= Time.deltaTime;
            if (castTimeCounter < 0.1)
            {
                thePHM.SetMaxHealth();
            }
        }

        if (castTimeCounter <= 0)
        {
            casting = false;
            myAnimator.SetBool("casting", false);
        }*/


        myAnimator.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        myAnimator.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        myAnimator.SetBool("moving", playerMoving);
        myAnimator.SetFloat("lastMoveX", lastMove.x);
        myAnimator.SetFloat("lastMoveY", lastMove.y);
    }

    /*void MoveCharacter()
    // Used in the commended out version
    {
        if (Mathf.Abs(change.x) > 0.5f && Mathf.Abs(change.y) > 0.5f)
        {
            currentMoveSpeed = moveSpeed * diagonalMoveModifier;
        } else
        {
            currentMoveSpeed = moveSpeed;
        }
        myRigidbody.MovePosition(
            transform.position + change * currentMoveSpeed * Time.deltaTime
        );
    }*/

}
