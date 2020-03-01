using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;


    void Start()
    {

        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
        Debug.Log(SceneManager.GetActiveScene());

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            Destroy(this.gameObject);
        }
    }
}
