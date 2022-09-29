using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //Character Controller Forward Speed
    
    public CharacterController controller;
    private Vector3 direction;
    public static float forwardSpeed=10f;
    public float maxSpeed=10f;

    //Changing Lanes ( Position of Player Left or Right )

    private int desiredLane = 1;//0:left 1:Middle 2:Right
    public float laneDistance = 2f;//The Distance Btw Two Lanes

    //Gravity and Jump Variables

    public float jumpForce;
    public float Gravity = -20;

    public Animator animator;
    private bool isSliding = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        forwardSpeed = 10f;
        animator.SetBool("isAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {

            if (!PlayerManager.isGameStarted)
                return;

            //To Increase Speed
            /*if(forwardSpeed<maxSpeed)
                forwardSpeed += 0.1f * Time.deltaTime;*/

            animator.SetBool("isGameStarted", true);

            direction.z = forwardSpeed;

            //Defining gravity and Jump Controls
            animator.SetBool("isGrounded", controller.isGrounded);
            if (controller.isGrounded)
            {

                if (SwipeManager.swipeUp && !isSliding)
                {
                    //direction.y = -1;
                    Jump();
                }
            }
            else
            {
                direction.y += Gravity * Time.deltaTime;
            }

            if (SwipeManager.swipeDown && !isSliding)
            {
                StartCoroutine(Slide());
            }

            //Gather the inputs on which lane we should be.

            if (SwipeManager.swipeRight)
            {
                //chkInput = true;
                desiredLane++;
                if (desiredLane == 3)
                    desiredLane = 2;
            }

            if (SwipeManager.swipeLeft)
            {
                //chkInput = true;
                desiredLane--;
                if (desiredLane == -1)
                    desiredLane = 0;
            }

            //Calculate where we should be in the future

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            else if (desiredLane == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }

            /*transform.position = Vector3.Lerp(transform.position, targetPosition, 50 * Time.fixedDeltaTime);
            controller.center = controller.center;*/

            if (transform.position != targetPosition)
            {
                Vector3 diff = targetPosition - transform.position;
                Vector3 moveDir = diff.normalized * 10 * Time.deltaTime;
                if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                    controller.Move(moveDir);
                else
                    controller.Move(diff);
            }

            //Move Player
            controller.Move(direction * Time.deltaTime);

        //Play Attack Animation
        if (Mission.isAtck)
        {
            animator.SetBool("isAttacking", true);
        }
    }

    

    private void Jump()
    {
        direction.y = jumpForce;
        FindObjectOfType<AudioManager>().PlaySound("Jump");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }

    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(-0.01f, 0, 0.17f);
        controller.height = 0.03f;
        FindObjectOfType<AudioManager>().PlaySound("Slide");
        yield return new WaitForSeconds(1.3f);

        controller.center = new Vector3(0f, 1.1f, 0f);
        controller.height = 2f;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }

    /*public IEnumerator BossEnd()
    {
        new WaitForSeconds(2f);
        forwardSpeed = 0f;
        //animator.SetBool("isBossFighting", true);

        for(int a = 0 ; PlayerHealth.currentHP<=0 ; a++)
        {
            new WaitForSeconds(0.5f);
            if (PlayerHealth.currentHP != 0)
            {
                    BossHealth.currentHP -= 5;
                    PlayerHealth.currentHP -= 5;
            }
            if(PlayerHealth.currentHP<=0)
            {
                PlayerHealth.Die();
                yield return new WaitForSeconds(0f);
            }
            if (BossHealth.currentHP <= 0)
            {
                BossHealth.Die();
            }
        }
        
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bossarena1")
        {
            desiredLane = 1;               
        }
    }
}
