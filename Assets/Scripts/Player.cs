using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform tr;
    Rigidbody rg;
    Animator animator;

    public float jumpForce = 3f;
    public float movementSpeed = 50f;
    bool lookingLeft = false;

    public void Start()
    {
        tr = GetComponent<Transform>();
        rg = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 force = new Vector3(0, jumpForce, 0);
            rg.AddForce(force, ForceMode.Impulse);
        }
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 move = new Vector3(movementSpeed, 0, 0);
            rg.AddForce(move);
            
            if (lookingLeft)
            {
                tr.Rotate(new Vector3(0, 180, 0));
                lookingLeft = false;
            }
            
            animator.SetFloat("Horizontal", Mathf.Abs(movementSpeed));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
            {
            Vector3 move = new Vector3(-movementSpeed, 0, 0);
            rg.AddForce(move);
            
            if (!lookingLeft)
            {
                tr.Rotate(new Vector3(0, 180, 0));
                lookingLeft = true;
            }
            
            animator.SetFloat("Horizontal", Mathf.Abs(movementSpeed));
        }
        {
            rg.velocity = new Vector3(0, rg.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 move = new Vector3(0, 0, movementSpeed);
            rg.AddForce(move);
            animator.SetFloat("Horizontal", Mathf.Abs(movementSpeed));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 move = new Vector3(0, 0, -movementSpeed);
            rg.AddForce(move);
            animator.SetFloat("Horizontal", Mathf.Abs(movementSpeed));
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rg.AddForce(new Vector3(0, 0, 0));
            animator.SetFloat("Horizontal", 0);
        }
    }
}
