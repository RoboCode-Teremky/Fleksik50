using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class lift : MonoBehaviour
{
    [SerializeField] private Transform firstpoimt;
    [SerializeField] private Transform secondPoint;
    private Rigidbody2D rb2d;
    [SerializeField] private float Speed =0.7f;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        rb2d.position = Vector3.Lerp(firstpoimt.position,secondPoint.position,Mathf.Ceil(Time.fixedTime)-Time.fixedTime);
    }
}

