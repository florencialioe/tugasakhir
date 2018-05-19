using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kuiskosakata : MonoBehaviour
{
    public class ContentKuisKosakata
    {
        public string ke { get; set; }
        public string hanzi { get; set; }
        public string isipilihan1 { get; set; }
        public string isipilihan2 { get; set; }
        public string isipilihan3 { get; set; }
        //public Button pilihjawaban { get; set; }
        
    }

    [Header("Content")]
    //[SerializeField] ContentBelajar[] arrayContent;
    [SerializeField] string[] ke;
    [SerializeField] string[] hanzi;
    [SerializeField] string[] isipilihan1;
    [SerializeField] string[] isipilihan2;
    [SerializeField] string[] isipilihan3;
    //[SerializeField] Button[] pilihjawaban;

    int SizeContent;
    int IndexContent;
  

    [Header("Holder")]
    [SerializeField] Text keHolder;
    [SerializeField] Text hanziHolder;
    [SerializeField] Text isipilihan1Holder;
    [SerializeField] Text isipilihan2Holder;
    [SerializeField] Text isipilihan3Holder;
    [SerializeField] Button pilihjawabanHolder;

    //[Header("Button")]
    //[SerializeField] GameObject NextButton;
    //[SerializeField] GameObject PrevButton;
    // Use this for initialization
    void Start()
    {
        SizeContent = ke.Length;
        IndexContent = 0;

        insertContent();

    }

    
    public void insertContent()
    {
        //keHolder.text = ke[IndexContent];
        //hanziHolder.text = hanzi[IndexContent];
        //isipilihan1Holder.text = isipilihan1[IndexContent];
        //isipilihan2Holder.text = isipilihan2[IndexContent];
        //isipilihan3Holder.text = isipilihan3[IndexContent];
        //pilihjawabanHolder.button = pilihjawaban[IndexContent];

        //sound
        //AudioHolder.Stop();
        //AudioHolder.clip = SoundAnimal[IndexContent];
        //AudioHolder.Play();
    }

    

// Update is called once per frame
void Update()
    {
        randQuestion = Random.Range(0, IndexContent);
       
       
        /*
        if (IndexContent < SizeContent - 1)
        {
            NextButton.SetActive(true);
        }
        else
        {
            NextButton.SetActive(false);
        }

        if (IndexContent == 0)
        {
            PrevButton.SetActive(false);
        }
        else
        {
            PrevButton.SetActive(true);
        }
        */
        
    }
    public static int randQuestion;
    /*public void RepeatSound()
    {
        AudioHolder.Stop();
        AudioHolder.Play();
    }*/

    /*public void NextContent()
    {
        if (IndexContent < SizeContent)
        {
            IndexContent++;
            insertContent();
        }

    }

    public void PrevContent()
    {
        if (IndexContent > 0)
        {
            IndexContent--;
            insertContent();
        }


    }*/
}
