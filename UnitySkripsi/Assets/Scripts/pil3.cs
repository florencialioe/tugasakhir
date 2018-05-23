using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pil3 : MonoBehaviour
{
    List<string> pilih3 = new List<string>() { "8", "12", "6", "13", "11", "17", "5", "9", "9", "15" };

    // Use this for initialization
    void Start()
    {
        //GetComponent<Text>().text = pilih3[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (kosakata.randQuestion > -1)
        {
            GetComponent<Text>().text = pilih3[kosakata.randQuestion];
        }
    }
    public void diKlik()
    {
        kosakata.pilihjawaban = "3";
        kosakata.pilihanditentukan = "y";
        Debug.Log(gameObject.name);
    }
    
}