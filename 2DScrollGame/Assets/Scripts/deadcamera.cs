using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadcamera : MonoBehaviour {

    Camera camera;
    bool colorchange = false;
    float a = 0;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        Invoke("chaange", 3f);
        Invoke("Quit", 10f);
	}
	
	// Update is called  once per frame
	void FixedUpdate () {

        a += 0.0015f;

        if (colorchange)
        {
            camera.backgroundColor = new Vector4(a, 0, 0, 1);
        }
    }

    void chaange()
    {
        colorchange = true;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
