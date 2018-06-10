using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pil1 : MonoBehaviour
{
    [SerializeField] string[] pilih1 = new string[] { "7", "10", "8", "15", "9", "16", "6", "8", "7", "16" };

    // Use this for initialization
    void Start()
    {
        //GetComponent<Text>().text = pilih1[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (kosakata.randQuestion > -1)
        {
            GetComponent<Text> ().text = pilih1[kosakata.randQuestion];
        }
    }

    public void diKlik()
    {
        kosakata.pilihjawaban = "1";
        kosakata.pilihanditentukan = "y";
        Debug.Log (gameObject.name);
    }
    
}