using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{

    public GameObject MeteorExplosion;
    public GameObject MeteorTerrain;

    // Use this for initialization
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, -30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 0.05f + Vector3.down * 0.2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Floor"))
        {
            Vector3 MeteorPosition = transform.position;
            GameObject object1 = (GameObject)Instantiate(MeteorExplosion, new Vector3(MeteorPosition.x, MeteorPosition.y - 0.7f, MeteorPosition.z), Quaternion.identity);
            GameObject object2 = (GameObject)Instantiate(MeteorTerrain, new Vector3(MeteorPosition.x, MeteorPosition.y - 1.2f, MeteorPosition.z), Quaternion.identity);
            Destroy(object1, 0.2f);
            Destroy(object2, 0.2f);
        }
        Destroy(gameObject);
    }

}
