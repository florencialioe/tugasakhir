﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalikKDaratBrp : MonoBehaviour
{
    //int sceneIndex;
    // Use this for initialization
    void Start()
    {
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("kdaratbrp");
    }
}
