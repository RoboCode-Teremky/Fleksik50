using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobinc : MonoBehaviour
{
[SerializeField] private Transform patrulPoint1, patrulPoint2;
[SerializeField] private float speed = 1.0f; 
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(patrulPoint1.position, patrulPoint2.position, Mathf.Sin(Time.time*speed)/2.0f + 0.5f);
    }
}
