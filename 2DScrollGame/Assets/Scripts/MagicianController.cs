using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianController : MonoBehaviour {

    public GameObject love;

    public GameObject Meteor;
    bool be_seduced = false;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Magic", 1.0f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if(be_seduced)
        {
            transform.Translate(Vector3.left * 0.05f);
        }
    }

    void Magic()
    {
        Instantiate(Meteor, new Vector3(transform.position.x -  0.0f, transform.position.y + 5.0f, transform.position.z), Quaternion.identity);
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 13)
        {
            be_seduced = true;
            Instantiate(love, new Vector3(transform.position.x - 3.0f, transform.position.y + 1.0f, transform.position.z), Quaternion.identity);

        }
    }
}
