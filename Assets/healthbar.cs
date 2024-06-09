using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    [SerializeField] private GameObject imagePrefab;
    void OnEble(){
        
        FindObjectOfType<playerlaunch>().
        GetComponent<playerlaunch>().
        healthChange.AddListener(UpdateBar);
    }
    void OnDisable(){
        FindObjectOfType<playerlaunch>().
        GetComponent<playerlaunch>().
        healthChange.RemoveListener(UpdateBar);
    }
    public void UpdateBar(int hp ){
        foreach (Transform child in transform){
            Destroy(child.gameObject);
        }
       for (int i=0; i < hp; i++)
       Instantiate(imagePrefab,transform); 
    }
    
    
}
