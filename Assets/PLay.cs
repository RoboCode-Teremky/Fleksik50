using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLay : MonoBehaviour
  
{
    public float speed = 1.0f; 
    public float jumpForce = 5f;

    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
       float movement = Input.GetAxis("Horizontal");
       transform.position +=  new Vector3(movement, 0, 0) *speed  * Time.deltaTime; 

       if (Input.GetKeyDown(KeyCode.Space))
       rigidbody2D.AddForce(new Vector2(0, jumpForce) , ForceMode2D.Impulse);

       
    }
}
