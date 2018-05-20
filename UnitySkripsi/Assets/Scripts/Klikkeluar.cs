using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Klikkeluar : MonoBehaviour {
    //int sceneIndex;
    public GameObject keluar;

	// Use this for initialization
	void Start () {
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
        keluar.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            keluar.SetActive(true);
        }

            //Application.Quit();
	}

}
