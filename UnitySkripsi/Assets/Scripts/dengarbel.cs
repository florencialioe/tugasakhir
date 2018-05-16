using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]

public class kete
{
    public Sprite gmbr;
    public string hanz;
    public string piny;
    public string art;
    public AudioClip rep;
}

public class dengarbel : MonoBehaviour
{
    public GameObject contohButton;
    public Transform contentPanell;
    public List<kete> itemListt;

    List<GameObject> isicoba;

    [SerializeField]
    public bool bac;
    [SerializeField]
    public bool hom;
    [SerializeField]
    public bool sta;
    [SerializeField]
    public bool beldeng;
    [SerializeField]
    public bool belmenu;
    [SerializeField]
    public bool nex;
    [SerializeField]
    public bool pre;

    public int indexx;
    Button back;
    Button home;
    Button next;
    Button previous;
    Button mendengar;

    void Start()
    {
        isicoba = new List<GameObject>();
        indexx = 0;
        DaftarPopulate();
        ShowIsii(indexx);
    }

    void DaftarPopulate()
    {
        GameObject newcanvas = Instantiate(contohButton) as GameObject;
        dengar2 buttonstatic = newcanvas.GetComponent<dengar2>();
        buttonstatic.back.SetActive(bac);
        buttonstatic.home.SetActive(hom);
        buttonstatic.star.SetActive(sta);
        buttonstatic.belajardengar.SetActive(beldeng);
        buttonstatic.belajarguratan.SetActive(belmenu);
        buttonstatic.next.SetActive(nex);
        buttonstatic.previous.SetActive(pre);

        foreach (var item in itemListt)
        {
            GameObject newButton = Instantiate(contohButton) as GameObject;
            dengar1 buttonScript = newButton.GetComponent<dengar1>();
            dengar2 buttonScript2 = newButton.GetComponent<dengar2>();
            Destroy(buttonScript2.back);
            Destroy(buttonScript2.home);
            Destroy(buttonScript2.next);
            Destroy(buttonScript2.previous);
            buttonScript.gambarhewan.sprite = item.gmbr;
            buttonScript.hanzi.text = item.hanz;
            buttonScript.pinyin.text = item.piny;
            buttonScript.arti.text = item.art;

            newButton.transform.SetParent(newcanvas.transform);
            newButton.SetActive(false);
            isicoba.Add(newButton);
        }
        newcanvas.transform.SetParent(contentPanell);
        back = buttonstatic.back.GetComponent<Button>();
        back.onClick.AddListener(() => changemenuscenee("halamanhewan"));

        home = buttonstatic.home.GetComponent<Button>();
        home.onClick.AddListener(() => changemenuscenee("halamanutama"));

        mendengar = buttonstatic.next.GetComponent<Button>();
        mendengar.onClick.AddListener(() => changemenuscenee("coba"));

        next = buttonstatic.next.GetComponent<Button>();
        next.onClick.AddListener(() => ButtonNextt());

        previous = buttonstatic.previous.GetComponent<Button>();
        previous.onClick.AddListener(() => ButtonPreviouss());
    }
    void OnDestroy()
    {
        back.onClick.RemoveListener(() => changemenuscenee("halamanhewan"));
        home.onClick.RemoveListener(() => changemenuscenee("halamanutama"));
        next.onClick.RemoveListener(() => ButtonNextt());
        previous.onClick.RemoveListener(() => ButtonPreviouss());
    }
    public void changemenuscenee(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    void ButtonNextt()
    {
        if (indexx < isicoba.Count)
        {
            indexx++;
            ShowIsii(indexx);
            Debug.Log("apapun");
        }
    }
    void ButtonPreviouss()
    {
        if (indexx > 0)
        {
            indexx--;
            ShowIsii(indexx);
        }

    }
    void ShowIsii(int i)
    {
        foreach (GameObject newButton in isicoba)
        {
            newButton.SetActive(false);
        }
        isicoba[i].SetActive(true);
    }
}