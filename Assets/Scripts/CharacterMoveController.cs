using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    private CharacterSoundController sound;
    [Header("Movement")]
    public float moveAccel;
    public float maxSpeed;
    // Start is called before the first frame update
    private Rigidbody2D rig;

    private void Start()
    {
    rig = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sound = GetComponent<CharacterSoundController>();
    }

    [Header("Ground Raycast")]
    public float groundRaycastDistance;
    public LayerMask groundLayerMask;

 

    private bool isOnGround;

    private void FixedUpdate()
    {
        // raycast ground
    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundRaycastDistance, groundLayerMask);
    if (hit)
    {
        if (!isOnGround && rig.velocity.y <= 1)
        {
            isOnGround = true;
        }
    }
    else
    {
        isOnGround = false;
    }

    // calculate velocity vector
    Vector2 velocityVector = rig.velocity;

    if (isJumping)
    {
        velocityVector.y += jumpAccel;
        isJumping = false;
    }




    
    velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);

    rig.velocity = velocityVector;


    
    }

    [Header("Jump")]
    public float jumpAccel;

    private bool isJumping;
  

    private void Update()
    {
     // read input
     if (Input.GetMouseButtonDown(0))
     {
         if (isOnGround)
         {
             isJumping = true;
             sound.PlayJump();
         }
     }
      // change animation
    anim.SetBool("isOnGround", isOnGround);
    }
    private Animator anim;

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * groundRaycastDistance), Color.white);
    }  
    
    
}
