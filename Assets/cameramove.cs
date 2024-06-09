using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float Speed = 1.0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
    void LateUpdate()
    {
        float z = transform.position.z;
        Vector3 newPosition = player.position;
        newPosition.z = transform.position.z;
        transform.position  = Vector3.Lerp(transform.position,newPosition,Speed*Time.deltaTime);
    }
}
