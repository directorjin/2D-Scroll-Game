using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bossmeteor : MonoBehaviour
{
    
    // Use this for initialization
    void Start()
    {
       // Destroy(gameObject, 12f);
        transform.rotation = Quaternion.Euler(0, 0, -30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 0.03f + Vector3.down * 0.1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Dead");
        }

        if (other.gameObject.CompareTag("defense"))
        {
            Destroy(gameObject);
        }
    }

}