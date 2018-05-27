using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]

public class itemcoba
{
    public bool kunci;
}

public class coba1 : MonoBehaviour
{
    public GameObject sampleButton;
    public Transform contentPanel;

    public GameObject sampleButton1;
    public Transform contentPanel1;

    public GameObject sampleButton2;
    public Transform contentPanel2;
    //public List<itemcoba> itemList;

    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        GameObject newButton = Instantiate(sampleButton) as GameObject;
        coba buttonScript = newButton.GetComponent<coba>();
        buttonScript.kunci.SetActive(true);

        GameObject newButton1 = Instantiate(sampleButton1) as GameObject;
        coba buttonScript1 = newButton.GetComponent<coba>();
        buttonScript1.kunci.SetActive(true);

        GameObject newButton2 = Instantiate(sampleButton2) as GameObject;
        coba buttonScript2 = newButton.GetComponent<coba>();
        buttonScript2.kunci.SetActive(true);


        bool finishAllQuizDarat = false;
        bool finishAllQuizAir = false;
        if (PlayerPrefs.GetInt("Kata") > 0 && PlayerPrefs.GetInt("Gambar") > 0 && PlayerPrefs.GetInt("Dengar") > 0)
        {
            finishAllQuizDarat = true;
        }

        if (PlayerPrefs.GetInt("KuisKataAir") > 0 && PlayerPrefs.GetInt("KuisGambarAir") > 0 && PlayerPrefs.GetInt("KuisDengarAir") > 0)
        {
            finishAllQuizAir = true;
        }


        if (finishAllQuizDarat == true)
        {
            buttonScript.kunci.SetActive(false);
        }

        if (finishAllQuizAir == true)
        {
            buttonScript1.kunci.SetActive(false);
        }
        
        //buttonScript2.kunci.SetActive(false);

        newButton.transform.SetParent(contentPanel);
        newButton1.transform.SetParent(contentPanel1);
        newButton2.transform.SetParent(contentPanel2);
   
    }
}