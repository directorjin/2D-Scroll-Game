using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossarrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * 0.25f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 10)
        {

            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Dead");
        }

        if(other.gameObject.CompareTag("defense"))
        {
            Destroy(gameObject);
        }
    }
}
