using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 50f;
    public float jumpForce = 3f;
    Transform tr;
    Rigidbody rg;
    // SpriteRenderer spriteRenderer;
    // Sprite sprite;
    bool lookingLeft = false;

    public void Start()
    {
        tr = GetComponent<Transform>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
        // sprite = Resources.Load<Sprite>("Sprites Hollow Knight");
        // spriteRenderer.sprite = sprite;
        rg = GetComponent<Rigidbody>();
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
        /* if(Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 move = new Vector3(movementSpeed, 0, 0);
            rg.AddForce(move);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
            {
            Vector3 move = new Vector3(-movementSpeed, 0, 0);
            rg.AddForce(move);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 move = new Vector3(0, 0, movementSpeed);
            rg.AddForce(move);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 move = new Vector3(0, 0, -movementSpeed);
            rg.AddForce(move);
        } */
        if(Input.GetKeyDown(KeyCode.LeftArrow) && !lookingLeft)
        {
            tr.Rotate(new Vector3(0, 180, 0));
            lookingLeft = true;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && lookingLeft)
        {
            tr.Rotate(new Vector3(0, 180, 0));
            lookingLeft= false;
        }
    }
}
