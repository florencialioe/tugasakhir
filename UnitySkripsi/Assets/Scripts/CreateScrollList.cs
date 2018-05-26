using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]

public class item
{
    public string han;
    public string pin;
    public string ar;
    public Sprite gambar;
    public bool star;
    public bool kunci;
}

public class CreateScrollList : MonoBehaviour {
    public GameObject sampleButton;
    public Transform contentPanel;
    public List<item> itemList;
    


    void Start()
    {
        PopulateList();
    
    }

  
    void PopulateList()
    {
        bool finishAllQuiz = false;
       if (PlayerPrefs.GetInt("Kata") > 0 && PlayerPrefs.GetInt("Gambar") > 0 && PlayerPrefs.GetInt("Dengar") > 0)
        {
            finishAllQuiz = true;
        }
        foreach (var item in itemList)
        {

            GameObject newButton = Instantiate(sampleButton) as GameObject;
            SampleButtonScript buttonScript = newButton.GetComponent<SampleButtonScript>();
            buttonScript.hanzi.text = item.han;
            buttonScript.pinyin.text = item.pin;
            buttonScript.arti.text = item.ar;
            buttonScript.gambarhewan.sprite = item.gambar;
            if (finishAllQuiz == true)
            {
                item.kunci = false;
            }


            if (item.star == true)
            {
                buttonScript.bintang.SetActive(true);
            }
            else
            {
                buttonScript.bintang.SetActive(false);
            }
            if (item.kunci == true)
            {
                buttonScript.kunci.SetActive(true);
            }
            else
            {
                buttonScript.kunci.SetActive(false);
            }

            newButton.transform.SetParent(contentPanel);
           
            
        }
    }
}