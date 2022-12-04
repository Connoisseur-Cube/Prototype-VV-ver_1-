using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    // Basic Script. Will be changed later or never, depending on the life and complexity of this project.
    //This is a prototype to test multiple things, hence I will not "polish" any more than necessary
    public Transform topleft;
    public Transform bottomright;
    public float speed = 10f;
    public float jumpspeed = 10f;
    private InputAccess Input;
    private Rigidbody2D rb;
    private BoxCollider2D Collider;
    public LayerMask Ground;
    public bool Grounded;
    private Animator anim;
    private string state;
    void Awake() 
    {
        Input = GetComponent<InputAccess>();
        rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        Grounded = Physics2D.OverlapArea(topleft.position,bottomright.position,Ground);
        
        if(Input.jump > 0f && Grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        }

        if(transform.localScale.x != 1 && rb.velocity.x >= 0.1){
            Facing(1f);
        }
        else if (transform.localScale.x != -1 && rb.velocity.x <= -0.1){
            Facing(-1f);
        }

        UpdateAnimation();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.move.x*speed*Time.fixedDeltaTime,rb.velocity.y);


    }

    void Facing(float face){
        transform.localScale = new Vector3(face,transform.localScale.y,transform.localScale.z);
    }

    void UpdateAnimation()
    {
        if(Mathf.Abs(rb.velocity.x) >= 0.1f && Mathf.Abs(rb.velocity.x) < 3f)
        {
            state = "walking";
        }
        else if (Mathf.Abs(rb.velocity.x) >= 3f){
            state = "Running";
        }
        else {
            state = "Idle";
        }

        if(rb.velocity.y >= 0.1f || rb.velocity.y <= -0.1f)
        {
            state = "Jump";
        }

        anim.Play($"Base Layer.{state}");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(topleft.position,new Vector2(bottomright.position.x,topleft.position.y));
        Gizmos.DrawLine(bottomright.position,new Vector2(topleft.position.x,bottomright.position.y));
        Gizmos.DrawLine(topleft.position,new Vector2(topleft.position.x,bottomright.position.y));
        Gizmos.DrawLine(bottomright.position, new Vector2(bottomright.position.x,topleft.position.y));

    }
    
}
