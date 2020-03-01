using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endingboss : MonoBehaviour {

    public GameObject cameraGO;
    public Text textbox;
    public AudioClip endingsong;

    AudioSource source;
    bool cameraon = false;

	// Use this for initialization
	void Start () {
        textbox.text = "";
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (cameraon)
        {
            cameraGO.transform.Translate(Vector3.down * 0.05f);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            cameraon = true;
            source.PlayOneShot(endingsong);
            Invoke("wintext", 5f);
        }
    }

    void wintext()
    {
        textbox.text = "The End\n\n You Win!";
        Invoke("resttime", 4f);
    }

    void resttime()
    {
        textbox.text = "";
        Invoke("epilogue", 3f);
    }

    void epilogue()
    {
        textbox.text = "제작: 멀티미디어공학과 2013112206 이어진\n\n\nSprite: Term project_Data(2dTD)";

        Invoke("exitmode", 60f);
    }

    void exitmode()
    {
    #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
    #else
           Application.Quit();
    #endif
    }
}
