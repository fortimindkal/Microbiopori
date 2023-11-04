using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            Debug.Log("Destroyed");
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Debug.Log("Destroyed");
        }
    }
}
