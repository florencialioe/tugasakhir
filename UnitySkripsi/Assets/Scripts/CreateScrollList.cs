using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]

public class item
{
    public string han;
    public string pin;
    public string ar;
    public Sprite gambar;
    public bool star;
    public bool kunci;
    public int index;
}

public class CreateScrollList : MonoBehaviour {
    public GameObject sampleButton;
    public Transform contentPanel;
    public List<item> itemList;
    [SerializeField] Text SearchText;

    private UnityAction m_MyFirstAction;
    public static int IndexButton = 0;

    void Start()
    {
        IndexButton = 0;
        PopulateList();
    
    }

    string itemNeedTOFound ="";
    public void buttonSearch()
    {
        itemNeedTOFound = SearchText.text;
        
        search();
    }
    public void deleteAllSearchItem()
    {
        GameObject[] listItemDes = GameObject.FindGameObjectsWithTag("Search");
        foreach (GameObject item in listItemDes)
        {
            Destroy(item);
        }
    }
    private List<item> tempItem;
    public void search() {
        deleteAllSearchItem();
        bool finishAllQuiz = false;
        if (PlayerPrefs.GetInt("Kata") > 0 && PlayerPrefs.GetInt("Gambar") > 0 && PlayerPrefs.GetInt("Dengar") > 0)
        {
            finishAllQuiz = true;
        }
        tempItem = new List<item>();
        int findresult = 0;
        foreach (var item in itemList)
        {
            if (item.ar.ToLower().Contains(itemNeedTOFound.ToLower()))
            {
                findresult++;
                tempItem.Add(item);
            }
        }
        foreach (var item in tempItem)
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
            if (item.kunci == false)
            {
                newButton.GetComponent<Button>().onClick.AddListener(delegate { PindahMendengar(item.index); });

            }
        }

        if (findresult == 0)
        {
            //do something
           // PopulateList();
        }
    }

    void PopulateList()
    {
        bool finishAllQuiz = false;
       if (PlayerPrefs.GetInt("Kata") > 0 && PlayerPrefs.GetInt("Gambar") > 0 && PlayerPrefs.GetInt("Dengar") > 0)
        {
            finishAllQuiz = true;
        }
        int i = 0;
        foreach (var item in itemList)
        {

            GameObject newButton = Instantiate(sampleButton) as GameObject;
            SampleButtonScript buttonScript = newButton.GetComponent<SampleButtonScript>();
            buttonScript.hanzi.text = item.han;
            buttonScript.pinyin.text = item.pin;
            buttonScript.arti.text = item.ar;
            buttonScript.gambarhewan.sprite = item.gambar;
            item.index = i;
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
            if (item.kunci == false) {
                newButton.GetComponent<Button>().onClick.AddListener(delegate { PindahMendengar(item.index); });

            }

            i++;
        }

    }
    
    void PindahMendengar(int index)
    {
        Debug.Log(index.ToString());
        IndexButton = index;
        SceneManager.LoadScene("belajarmendengar");

    }
}