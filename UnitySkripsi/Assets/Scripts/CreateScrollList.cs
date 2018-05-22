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
}

public class CreateScrollList : MonoBehaviour {
    public GameObject sampleButton;
    public Transform contentPanel;
    public List<item> itemList;

    //[SerializeField] ScrollRect scrollRect;
    //[SerializeField] RectTransform content_Panel;
    //[SerializeField] Vector2 valueX;

    void Start()
    {
        PopulateList();
       // Snapto(valueX);
    }

    //public void Snapto(Vector2 alue)
   // {
   //    Canvas.ForceUpdateCanvases();
      // content_Panel.anchoredPosition = (Vector2)scrollRect.transform.InverseTransformPoint(alue);

    //}

    //private void Update()
    //{
        //Snapto(valueX);
   // }
    void PopulateList()
    {
        foreach (var item in itemList)
        {
            GameObject newButton = Instantiate(sampleButton) as GameObject;
            SampleButtonScript buttonScript = newButton.GetComponent<SampleButtonScript>();
            buttonScript.hanzi.text = item.han;
            buttonScript.pinyin.text = item.pin;
            buttonScript.arti.text = item.ar;
            buttonScript.gambarhewan.sprite = item.gambar;
            buttonScript.bintang.SetActive(item.star);

            newButton.transform.SetParent(contentPanel);
        }
    }
}