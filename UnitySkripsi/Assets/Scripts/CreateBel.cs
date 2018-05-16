using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]

public class ket
{
    public Sprite gmbrhwn;
    public string han;
    public string pin;
    public string ar;
}

public class CreateBel : MonoBehaviour
{
    public GameObject sampleButton;
    public Transform contentPanel;
    public List<ket> itemList;

    List<GameObject> isi;

    [SerializeField]
    public bool ba;
    [SerializeField]
    public bool ho;
    [SerializeField]
    public bool st;
    [SerializeField]
    public bool belden;
    [SerializeField]
    public bool belmen;
    [SerializeField]
    public bool re;
    [SerializeField]
    public bool ne;
    [SerializeField]
    public bool pr;

    public int index;
    Button back;
    Button home;
    Button next;
    Button previous;
    Button belajarmendengar;

    void Start()
    {
        isi = new List<GameObject>();
        index = 0;
        PopulateList();
        ShowIsi(index);
    }

    void PopulateList()
    {
        GameObject newcanvas = Instantiate(sampleButton) as GameObject;
        coba2 buttonstatic = newcanvas.GetComponent<coba2>();
        buttonstatic.back.SetActive(ba);
        buttonstatic.home.SetActive(ho);
        buttonstatic.star.SetActive(st);
        buttonstatic.belajarmendengar.SetActive(belden);
        buttonstatic.belajarmenulis.SetActive(belmen);
        buttonstatic.repeat.SetActive(re);
        buttonstatic.next.SetActive(ne);
        buttonstatic.previous.SetActive(pr);

        foreach (var item in itemList)
        {
            GameObject newButton = Instantiate(sampleButton) as GameObject;
            coba buttonScript = newButton.GetComponent<coba>();
            coba2 buttonScript2 = newButton.GetComponent<coba2>();
            Destroy(buttonScript2.back);
            Destroy(buttonScript2.home);
            Destroy(buttonScript2.next);
            Destroy(buttonScript2.previous);
            buttonScript.gambarhewan.sprite = item.gmbrhwn;
            buttonScript.hanzi.text = item.han;
            buttonScript.pinyin.text = item.pin;
            buttonScript.arti.text = item.ar;

            newButton.transform.SetParent(newcanvas.transform);
            newButton.SetActive(false);
            isi.Add(newButton);
        }
        newcanvas.transform.SetParent(contentPanel);

        back = buttonstatic.back.GetComponent<Button>();
        back.onClick.AddListener(() => changemenuscene("halamanhewan"));

        home = buttonstatic.home.GetComponent<Button>();
        home.onClick.AddListener(() => changemenuscene("halamanutama"));

        belajarmendengar = buttonstatic.next.GetComponent<Button>();
        belajarmendengar.onClick.AddListener(() => changemenuscene("coba"));

        next = buttonstatic.next.GetComponent<Button>();
        next.onClick.AddListener(() => ButtonNext());

        previous = buttonstatic.previous.GetComponent<Button>();
        previous.onClick.AddListener(() => ButtonPrevious());
    }
    void OnDestroy()
    {
        back.onClick.RemoveListener(() => changemenuscene("halamanhewan"));
        home.onClick.RemoveListener(() => changemenuscene("halamanutama"));
        next.onClick.RemoveListener(() => ButtonNext());
        previous.onClick.RemoveListener(() => ButtonPrevious());
    }
    public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    void ButtonNext()
    {
        if (index < isi.Count)
        {
            index++;
            ShowIsi(index);
            Debug.Log("apapun");
        }
    }
    void ButtonPrevious()
    {
        if (index > 0)
        {
            index--;
            ShowIsi(index);
        }

    }
    void ShowIsi(int i)
    {
        foreach (GameObject newButton in isi)
        {
            newButton.SetActive(false);
        }
        isi[i].SetActive(true);
    }
}