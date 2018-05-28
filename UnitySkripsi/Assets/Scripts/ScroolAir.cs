using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]

public class itemair
{
    public string han;
    public string pin;
    public string ar;
    public Sprite gambar;
    public bool star;
    public bool kunci;
    public int indexa;
}

public class ScroolAir : MonoBehaviour
{
    public GameObject sampleButton;
    public Transform contentPanel;
    public List<itemair> itemList;
    [SerializeField] Text TextSearch;

    private UnityAction m_MyFirstAction;
    public static int IndexButtona = 0;

    void Start()
    {
        IndexButtona = 0;
        PopulateList();

    }

    string itemNeedTOFounda = "";
    public void buttonSearch()
    {
        itemNeedTOFounda = TextSearch.text;

        search();
    }

    public void deleteAllSearchItemair()
    {
        GameObject[] listItemDesair = GameObject.FindGameObjectsWithTag("search");
        foreach (GameObject itemair in listItemDesair)
        {
            Destroy(itemair);
        }
    }
    private List<itemair> tempItemair;

    public void search()
    {
        deleteAllSearchItemair();
        bool finishAllQuiz = false;
        if (PlayerPrefs.GetInt("KuisKataAir") > 0 && PlayerPrefs.GetInt("KuisGambarAir") > 0 && PlayerPrefs.GetInt("KuisDengarAir") > 0)
        {
            finishAllQuiz = true;
        }
        tempItemair = new List<itemair>();
        int findresulta = 0;
        foreach (var itemair in itemList)
        {
            if (itemair.ar.ToLower().Contains(itemNeedTOFounda.ToLower()))
            {
                findresulta++;
                tempItemair.Add(itemair);
            }
        }
        foreach (var itemair in tempItemair)
        {

            GameObject newButton = Instantiate(sampleButton) as GameObject;
            buttonair buttonScript = newButton.GetComponent<buttonair>();
            buttonScript.hanzi.text = itemair.han;
            buttonScript.pinyin.text = itemair.pin;
            buttonScript.arti.text = itemair.ar;
            buttonScript.gambarhewan.sprite = itemair.gambar;
            if (finishAllQuiz == true)
            {
                itemair.kunci = false;
            }


            if (itemair.star == true)
            {
                buttonScript.bintang.SetActive(true);
            }
            else
            {
                buttonScript.bintang.SetActive(false);
            }
            if (itemair.kunci == true)
            {
                buttonScript.kunci.SetActive(true);
            }
            else
            {
                buttonScript.kunci.SetActive(false);
            }

            newButton.transform.SetParent(contentPanel);
            if (itemair.kunci == false)
            {
                newButton.GetComponent<Button>().onClick.AddListener(delegate { PindahMendengar(itemair.indexa); });

            }
        }

        if (findresulta == 0)
        {
            //do something
            // PopulateList();
        }
    }

    void PopulateList()
    {
        bool finishAllQuiz = false;
        if (PlayerPrefs.GetInt("KuisKataAir") > 0 && PlayerPrefs.GetInt("KuisGambarAir") > 0 && PlayerPrefs.GetInt("KuisDengarAir") > 0)
        {
            finishAllQuiz = true;
        }
        int i = 0;
        foreach (var itemair in itemList)
        {

            GameObject newButton = Instantiate(sampleButton) as GameObject;
            buttonair buttonScript = newButton.GetComponent<buttonair>();
            buttonScript.hanzi.text = itemair.han;
            buttonScript.pinyin.text = itemair.pin;
            buttonScript.arti.text = itemair.ar;
            buttonScript.gambarhewan.sprite = itemair.gambar;
            itemair.indexa = i;
            if (finishAllQuiz == true)
            {
                itemair.kunci = false;
            }


            if (itemair.star == true)
            {
                buttonScript.bintang.SetActive(true);
            }
            else
            {
                buttonScript.bintang.SetActive(false);
            }
            if (itemair.kunci == true)
            {
                buttonScript.kunci.SetActive(true);
            }
            else
            {
                buttonScript.kunci.SetActive(false);
            }

            newButton.transform.SetParent(contentPanel);
            if (itemair.kunci == false)
            {
                newButton.GetComponent<Button>().onClick.AddListener(delegate { PindahMendengar(itemair.indexa); });

            }

            i++;
        }

    }

    void PindahMendengar(int indexa)
    {
        Debug.Log(indexa.ToString());
        IndexButtona = indexa;
        SceneManager.LoadScene("DengarAir");

    }
}