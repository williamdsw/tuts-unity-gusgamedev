using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //-----------------------------------------------------------------//
    // FIELDS

    // Config
    [SerializeField] private float speed = 10f;
    private float timeToSelfDestruct = 1f;

    //-----------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS
    
    private void Start () 
    {
        Destroy (this.gameObject, timeToSelfDestruct);
    }

    private void Update () 
    {
        this.transform.Translate (Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy (this.gameObject);
    }
}