using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class OrcController : MonoBehaviour
{
    public GameObject deadorc;
    public float movePower = 2f;
    new SpriteRenderer renderer;
    bool isDie = false;



    // Use this for initialization
    void Start()
    {
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!isDie)
        {
            float moveDelta;
            if (renderer.flipX == false)
            {
                moveDelta = movePower * Time.deltaTime;
                transform.Translate(moveDelta, 0, 0);
            }
            else
            {
                moveDelta = movePower * Time.deltaTime * -1f;
                transform.Translate(moveDelta, 0, 0);
            }
        }
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Invisible_wall"))
        {
            if (renderer.flipX == true)
            {
                renderer.flipX = false;
            }
            else if (renderer.flipX == false)
            {
                renderer.flipX = true;
            }
        }

    }

    public void Die()
    {
        isDie = true;
        Instantiate(deadorc, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}