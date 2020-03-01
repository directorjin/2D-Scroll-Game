using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxscript : MonoBehaviour
{

    void Start()
    {
      

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 11)
        {
            OrcController Orc = other.gameObject.GetComponent<OrcController>();
            Orc.Die();
        }

        if (other.gameObject.layer == 12)
        {
            //kill creature
            BatController Bat = other.gameObject.GetComponent<BatController>();
            Bat.Die();
        }
    }

}