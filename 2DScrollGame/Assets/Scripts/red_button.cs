using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_button : MonoBehaviour {

    public float button_delay = 2f;
    public GameObject Arrow;
    public AudioClip Arrow_before;
    public AudioClip Arrow_after;
    public GameObject cooldown;
    public GameObject Offense_Tower;

    Vector3 childposition;
    bool shoot = false;
    bool makearrow = false;

    Quaternion arrowrot;

    GameObject clone1;
    GameObject clone2;

    GameObject clock;

    AudioSource source;

     //Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();        
	}

    //Update is called once per frame
    
    void FixedUpdate()
    {
        if (shoot)
        {
            Invoke("destroyGO", 2f);
            clone2.transform.Translate(Vector3.right * 0.4f);
            clone2.transform.Rotate(Vector3.back * 2.5f);
        }

        if (makearrow)
        {
            clone1.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.PingPong(Time.time * 90.0f, 90));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shoot = false;

            childposition = Offense_Tower.transform.position;

            //GameObject child = transform.Find("Offense_Tower").gameObject;
            //childposition = child.transform.position;

            transform.Translate(0, -0.1f, 0);
            clone1 = Instantiate(Arrow, new Vector3(childposition.x, childposition.y + 0.5f, childposition.z), Arrow.transform.rotation) as GameObject;
            makearrow = true;
            source.PlayOneShot(Arrow_before);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            clock = Instantiate(cooldown, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity) as GameObject;
            makearrow = false;
            source.PlayOneShot(Arrow_after);
            arrowrot = clone1.transform.rotation;
            Destroy(clone1);

            clone2 = Instantiate(Arrow, new Vector3(childposition.x, childposition.y + 0.5f, childposition.z), arrowrot) as GameObject;
            shoot = true;
            Invoke("ButtonUp", button_delay);
        }

    }

    private void ButtonUp()
    {
        transform.Translate(0, 0.1f, 0);
        
    }

    private void destroyGO()
    {
        shoot = false;
    }

}
