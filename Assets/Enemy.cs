using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody rg;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float num = Random.Range(-20f, 20f);
        Vector3 worldDirection = transform.forward;
        rg.AddForce(new Vector3(worldDirection.x + num + speed, 0, 0));
    }
}
