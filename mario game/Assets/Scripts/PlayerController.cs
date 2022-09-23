using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public float jumpForce;
    private bool canMove;
    private Rigidbody2D theRB2D;

    public bool grounded;
    public LayerMask whatIsGrd;
    public Transform grdChecker;
    public float grdCheckerRad;

    public float airTime;
    public float airTimeCounter;

    private Animator theAnimator;



    // Start is called before the first
    // frame update
    void Start()
    {
        theRB2D = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();

        airTimeCounter = airTime; 
    }

    // Update is called once per frame
   void Update()
    {
        if(Input.GetAxisRaw("Horizontal")> 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            canMove = true;
        }
        Debug.Log(theRB2D.position.y);
    }

    private void FixedUpdate()
    {
      grounded = Physics2D.OverlapCircle(grdChecker.position, grdCheckerRad, whatIsGrd);
        
       MovePlayer();
       Jump();
       Superjump();
       Teleport();
    }

    void MovePlayer()
    {
        if (canMove)
        {
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y);

            theAnimator.SetFloat("Speed", Mathf.Abs(theRB2D.velocity.x));
            Debug.Log("bla");
        }

    }

    void Jump()
    {
       
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if(theRB2D.position.y < -3.98)
                {
                    theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
            }
                
                
            }

        

    }

    void Superjump()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (theRB2D.position.y < -2)
            {
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, 30);
            }


        }



    }

    void Teleport()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {

            theRB2D.position = new Vector2(0, 0); 
        }



    }

}

