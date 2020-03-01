using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class BossControl : MonoBehaviour {

    public GameObject player;
    public AudioClip enginesound;
    public AudioClip damagesound;
    public AudioClip siren;
    public GameObject meteor;
    public GameObject arrowrain;
    public Text boss_text;
    

    public float movePower = 3f;
    
    bool move = true;
    new SpriteRenderer renderer;

    AudioSource source;

    private int boss_HP = 20;
    private int attackthird = 3;

    Color normalColor;
    Color beAttackedColor;
    SpriteRenderer thiscolor;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("meteorr", 3f, 15f);

        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        source = GetComponent<AudioSource>();

        thiscolor = gameObject.GetComponent<SpriteRenderer>();
        normalColor = thiscolor.color;
        beAttackedColor = normalColor;
        beAttackedColor.g -= 0.5f;
        beAttackedColor.b -= 0.5f;

        bossHP();
    }
	
	// Update is called once per frame
	void Update () {

        if (move)
        {
            float moveDelta;
            if (renderer.flipX == false)
            {
                moveDelta = movePower * Time.deltaTime;
                StartCoroutine("move_boss",moveDelta);
            }
            else
            {
                moveDelta = movePower * Time.deltaTime * -1f;
                StartCoroutine("move_boss", moveDelta);
            }
        }
      
	}

    void moveBoss()
    {

        transform.Translate(Vector3.left * 0.1f);
    }

    void meteorr()
    {
        Instantiate(meteor, new Vector3(player.transform.position.x + 6f, player.transform.position.y + 6f, player.transform.position.z),Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Invisible_wall"))
        {
            if (renderer.flipX == true)
            {
                renderer.flipX = false;
                StartCoroutine("engine_sound");
            }
            else if (renderer.flipX == false)
            {
                renderer.flipX = true;
                StartCoroutine("engine_sound");
            }
        }

        if (other.gameObject.layer == 10) //player
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Dead");
        }

        if (other.gameObject.layer == 15) //arrow
        {
            boss_HP -= 2;
            bossHP();
            attackthird--;
            other.gameObject.SetActive(false);

            StartCoroutine("beAttackedEffect");

            if (attackthird == 0)
            {
                source.PlayOneShot(siren);
                Invoke("arrow_rain", 4f);
                attackthird = 3;
            }

            if (boss_HP == 0)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("Ending");
            }

            if (boss_HP <= 5)
            {
                movePower = 6f; 
            }


        }

    }

    protected IEnumerator engine_sound()
    {
        source.PlayOneShot(enginesound);
        yield break;
    }

     IEnumerator move_boss(float moveDelta)
    {
        transform.Translate(moveDelta, 0, 0);
        return null;
    }

    IEnumerator beAttackedEffect()
    {
        source.PlayOneShot(damagesound);
        thiscolor.color = beAttackedColor;
        yield return new WaitForSeconds(2f);
        thiscolor.color = normalColor;
    }

    private void arrow_rain()
    {
        Instantiate(arrowrain);
    }

    void bossHP()
    {
        boss_text.text = "Boss HP: " + boss_HP.ToString();
    }
}
