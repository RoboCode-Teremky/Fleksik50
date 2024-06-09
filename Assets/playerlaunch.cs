using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class playerlaunch : MonoBehaviour
{
[SerializeField] private float launchForce = 1.0f;
[SerializeField] private float minSpeed = 0.1f;
[SerializeField] private int maxHP = 3;
private int currentHP;
public UnityEvent<int>healthChange = new UnityEvent<int>();
[SerializeField] private Transform spawnPoint;
private Vector3 startPosition;
private Vector3 launchDirection;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = spawnPoint.position;
        currentHP=maxHP;
healthChange.Invoke(currentHP);
    }

    // Update is called once per frame

     private void OnMouseDown(){
startPosition = rb2d.position;
     }
    private void OnMouseDrag()
    {
launchDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPosition;
    }
     
     void OnMouseUp()
     {
        rb2d.AddForce(new Vector2(launchDirection.x, launchDirection.y)*launchForce,ForceMode2D.Impulse); 
     }
     void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Saw")){
            transform.position = spawnPoint.position;
            currentHP--;
           if (currentHP<=0)
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           healthChange.Invoke(currentHP);  
        }
        if(other.gameObject.CompareTag("kit")){
            Destroy(other.gameObject);
            currentHP++;
healthChange.Invoke(currentHP);
        }
     }
}
