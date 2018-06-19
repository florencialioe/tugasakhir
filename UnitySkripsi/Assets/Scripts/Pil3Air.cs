using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pil3Air : MonoBehaviour
{
    [SerializeField] string[] pilih3 = new string[] { "8", "12", "6", "13", "11", "17", "5", "9", "9", "15" };

    // Use this for initialization
    void Start()
    {
        //GetComponent<Text>().text = pilih3[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (KuisKataAir.randQuestion > -1)
        {
            GetComponent<Text>().text = pilih3[KuisKataAir.randQuestion];
        }
    }
    public void diKlik()
    {
        KuisKataAir.pilihjawaban = "3";
        KuisKataAir.pilihanditentukan = "y";
        Debug.Log(gameObject.name);
    }

}