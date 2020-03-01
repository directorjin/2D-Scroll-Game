using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{

    public float movePower = 3f;
    Animator animator;
    new SpriteRenderer renderer;
    Rigidbody2D rb2d;
    bool isDie = false;
    public GameObject bat_deadbody;

    float moveDelta;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isDie)
        {
            
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

        if (isDie)
        {
            transform.Translate(Vector3.down * 0.05f);
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

        //if (other.gameObject.CompareTag("Player"))
        //{
        //    Debug.Log("tag");

        //    Destroy(gameObject);
        //}
    }
    

    public void Die()
    {
        animator.SetTrigger("BatDie");
        //rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        renderer.flipY = true;
        //transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        Vector3 newposition = transform.position;
        Instantiate(bat_deadbody, newposition, Quaternion.identity);
        isDie = true;
        Destroy(gameObject);

        
    }
}   