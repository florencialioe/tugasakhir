using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pil2 : MonoBehaviour
{
    List<string> pilih2 = new List<string>() { "6", "11", "7", "14", "10", "18", "7", "7", "8", "14" };

    // Use this for initialization
    void Start()
    {
        //GetComponent<Text>().text = pilih2[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (kosakata.randQuestion > -1)
        {
            GetComponent<Text>().text = pilih2[kosakata.randQuestion];
        }
    }
    void OnMouseDown()
    {
        kosakata.pilihjawaban = gameObject.name;
        kosakata.pilihanditentukan = "y";
        //Debug.Log(gameObject.name);
    }
}
