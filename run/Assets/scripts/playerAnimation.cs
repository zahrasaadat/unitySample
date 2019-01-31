using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour {
    private Animator MyAnim;
    private Rigidbody2D MyRigid;
    private bool gameStarted;
    public LayerMask groundLayer;
    public float jump=100f;
    public Transform checkGroundPos;
    public float radius = 0.5f;
    public bool isGrounded;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    private BGscroller bgscroll;
    private moonscroller grndScroll;
    void Awake()
    {
        MyAnim = GetComponent<Animator>();
        MyRigid = GetComponent<Rigidbody2D>();
        dragDistance = Screen.height * 15 / 100;
        bgscroll = GameObject.Find("background").GetComponent<BGscroller>();
        grndScroll = GameObject.Find("ground").GetComponent<moonscroller>();
    }
	void Start () {
        StartCoroutine(StartGame());
	}
	void playerJump() {
     
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;
                if (Mathf.Abs(lp.y - fp.y) > dragDistance && lp.y > fp.y && gameStarted && isGrounded )
                {
                    MyAnim.SetBool("jump", true);
                    //MyAnim.SetFloat("run", 0.3f);
                    MyRigid.AddForce(new Vector3(0, jump,0),ForceMode2D.Impulse);
                  

                }
             

            }
        }
        else if (isGrounded)
        {
              
                //MyAnim.SetFloat("run", 1f);
                MyAnim.SetBool("jump", false);
            
        }
       


    }
        void PlayerGrounded()
    {
        isGrounded= Physics2D.OverlapCircle(checkGroundPos.position, radius, groundLayer);
    }
	void FixedUpdate () {
        if (gameStarted)
        {
            MyAnim.SetFloat("run",1f);
            PlayerGrounded();
        }
        playerJump();
	}
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);
        gameStarted = true;
        bgscroll.canScroll = true;
        grndScroll.grndCanScroll = true;
    }

}
