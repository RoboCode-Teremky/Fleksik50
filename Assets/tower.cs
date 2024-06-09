using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tower : MonoBehaviour
{
    private ParticleSystem ps;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
collider2D = GetComponent<Collider2D>();
spriteRenderer = GetComponent<SpriteRenderer>();
    }

void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Player")){
        spriteRenderer.sprite = null;
        collider2D.enabled = false;
        ps.Play();
    }
}
   
}
