using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pil2 : MonoBehaviour
{
    [SerializeField] string[] pilih2 = new string[] { "6", "11", "7", "14", "10", "18", "7", "7", "8", "14" };

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
    public void diKlik()
    {
        kosakata.pilihjawaban = "2";
        kosakata.pilihanditentukan = "y";
        Debug.Log(gameObject.name);
    }
}
