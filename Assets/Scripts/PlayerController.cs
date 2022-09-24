using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Variables del movimiento del personaje
    public float jumpForce = 6f;
    Rigidbody2D rigidBody;
    Animator animator;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";

    public LayerMask groundMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Jump();
        }

        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());


        Debug.DrawRay(this.transform.position, Vector2.down*1.5f, Color.red);
    }

    void Jump()
    {
        if(IsTouchingTheGround())
        {
        rigidBody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsTouchingTheGround(){
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 1.5f, groundMask)){
            //TODO: Programar logica de contacto con el suleo
            //animator.enabled = true;
            return true;
        } else {
            //TODO: programar logica d econtacto
           // animator.enabled = false;
            return false;
        }
    }
}
