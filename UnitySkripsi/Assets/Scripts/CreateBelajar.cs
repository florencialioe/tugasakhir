using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBelajar : MonoBehaviour {
    public class ContentBelajar {
        public Sprite ImagesAnimal { get; set; }
        public string Hanzi { get; set; }
        public string Pinyin { get; set; }
        public string Meaning { get; set; }
        public AudioClip SoundAnimal { get; set; }
    }
    [Header("Content")]
    //[SerializeField] ContentBelajar[] arrayContent;
    [SerializeField] Sprite[] ImagesAnimal;
    [SerializeField] string[] Hanzi;
    [SerializeField] string[] Pinyin;
    [SerializeField] string[] Meaning;
    [SerializeField] AudioClip[] SoundAnimal;

    int SizeContent;
    int IndexContent;

    [Header("Holder")]
    [SerializeField] Image ImagesHolder;
    [SerializeField] Text HanziHolder;
    [SerializeField] Text PinyinHolder;
    [SerializeField] Text MeaningHolder;
    [SerializeField] AudioSource AudioHolder;

    [Header("Button")]
    [SerializeField] GameObject NextButton;
    [SerializeField] GameObject PrevButton;
	// Use this for initialization
	void Start () {
        SizeContent = ImagesAnimal.Length;
        IndexContent = 0;

        insertContent();
      

    }
    public void insertContent()
    {
        ImagesHolder.sprite = ImagesAnimal[IndexContent];
        HanziHolder.text = Hanzi[IndexContent];
        PinyinHolder.text = Pinyin[IndexContent];
        MeaningHolder.text = Meaning[IndexContent];
        //sound
        //AudioHolder.Stop();
        //AudioHolder.clip = SoundAnimal[IndexContent];
        //AudioHolder.Play();
    }
    // Update is called once per frame
    void Update () {
        if (IndexContent < SizeContent-1)
        {
            NextButton.SetActive(true);
        }
        else {
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
    }

    public void RepeatSound() {
        AudioHolder.Stop();
        AudioHolder.Play();
    }

    public void NextContent() {
        if (IndexContent < SizeContent) {
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
       

    }

}