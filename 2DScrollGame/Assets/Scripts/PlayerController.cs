using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movePower = 5f;
    public float jumpPower = 12f;
    public AudioClip attacksound;

    Rigidbody2D rb2d;
    new SpriteRenderer renderer;
    Animator animator;

    Vector3 movement;
    bool isJumping = false;
    AudioSource source;

    //bool JumpPossible = true;public AudioClip enginesound;


    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("IsMoving", false);
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            renderer.flipX = true;
            animator.SetBool("IsMoving", true);
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            renderer.flipX = false;
            animator.SetBool("IsMoving", true);
        }

            if (Input.GetButtonDown("Jump") && !animator.GetBool("IsJumping"))
            {
                isJumping = true;
                animator.SetBool("IsJumping", true);
                animator.SetTrigger("PlayerJump");
            }

	}

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move ()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump ()
    {
        if (!isJumping)
        {
            return;
        }

        rb2d.velocity = Vector2.zero;
        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rb2d.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Button"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Boss");
        }

        if ((other.gameObject.layer == 8 || other.gameObject.layer == 11 || other.gameObject.layer == 12 || other.gameObject.layer == 13) && rb2d.velocity.y < -1f)
        {
            animator.SetBool("IsJumping", false);
            //JumpPossible = true;
        }

        if (other.gameObject.layer == 11) //orc
        {
            //kill creature
            source.PlayOneShot(attacksound);
            OrcController Orc = other.gameObject.GetComponent<OrcController>();
            Orc.Die();
        }

        if (other.gameObject.layer == 11 && !(rb2d.velocity.y < -4f)) //orc
        {
            SceneManager.LoadScene("Dead");
        }


        if (other.gameObject.CompareTag("bat")) //bat
        {
            //kill creature
            source.PlayOneShot(attacksound);
            BatController Bat = other.gameObject.GetComponent<BatController>();
            Bat.Die();
        }

        if (other.gameObject.layer == 17) //deadzone
        {
            SceneManager.LoadScene("Dead");
        }

        if(other.gameObject.layer == 18) //meteor
        {
            SceneManager.LoadScene("Dead");
        }

    }
    
}
