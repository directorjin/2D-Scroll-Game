using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadplayer : MonoBehaviour {

    public GameObject dieplayer;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            Instantiate(dieplayer, new Vector3(-0.3198709f, -1.622381f, 0), Quaternion.identity);
        }
    }
}
