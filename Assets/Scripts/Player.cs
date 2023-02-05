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
            animator.SetBool("hasJump", true);
            Invoke("FromJumpToIdle", 1.3f);
        }
    }

    private void FromJumpToIdle()
    {
        animator.SetBool("hasJump", false);
    }

    private void Move()
    {
        Attacks();
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 move = new Vector3(movementSpeed, 0, 0);
            rg.AddForce(move);

            if (lookingLeft)
            {
                tr.Rotate(new Vector3(0, 180, 0));
                lookingLeft = false;
            }

            animator.CrossFade("Player_walk", .001f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 move = new Vector3(-movementSpeed, 0, 0);
            rg.AddForce(move);

            if (!lookingLeft)
            {
                tr.Rotate(new Vector3(0, 180, 0));
                lookingLeft = true;
            }

            animator.CrossFade("Player_walk", 0.001f);
        }
        {
            rg.velocity = new Vector3(0, rg.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 move = new Vector3(0, 0, movementSpeed);
            rg.AddForce(move);
            animator.CrossFade("Player_walk", 0.001f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 move = new Vector3(0, 0, -movementSpeed);
            rg.AddForce(move);
            animator.CrossFade("Player_walk", 0.001f);

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rg.AddForce(new Vector3(0, 0, 0));
            animator.Play("Player_stop", 0, 0f);
            animator.Play("Player_idle", 0, 1f);
        }
    }

    private void Attacks()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.CrossFade("Player_attack", 0.001f);
        }
    }
}
