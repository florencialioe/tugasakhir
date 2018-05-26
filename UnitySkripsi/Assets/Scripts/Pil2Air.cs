using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pil2Air : MonoBehaviour
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
        if (KuisKataAir.randQuestion > -1)
        {
            GetComponent<Text>().text = pilih2[KuisKataAir.randQuestion];
        }
    }
    public void diKlik()
    {
        KuisKataAir.pilihjawaban = "2";
        KuisKataAir.pilihanditentukan = "y";
        Debug.Log(gameObject.name);
    }
}
