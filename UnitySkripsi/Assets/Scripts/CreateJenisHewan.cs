using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]

public class keterangan
{
    public string han;
    public string pin;
    public string ar;
    public Sprite gambar;
    public bool star;
}

public class CreateJenisHewan : MonoBehaviour
{
    public GameObject sampleButton;
    public Transform contentPanel;
    public List<keterangan> itemList;

    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        foreach (var item in itemList)
        {
            GameObject newButton = Instantiate(sampleButton) as GameObject;
            buttonjenishewanScript buttonScript = newButton.GetComponent<buttonjenishewanScript>();
            buttonScript.hanzi.text = item.han;
            buttonScript.pinyin.text = item.pin;
            buttonScript.arti.text = item.ar;
            buttonScript.gambarhewan.sprite = item.gambar;
            buttonScript.bintang.SetActive(item.star);

            newButton.transform.SetParent(contentPanel);
        }
    }
}
