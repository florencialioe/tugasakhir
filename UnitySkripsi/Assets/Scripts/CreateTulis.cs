using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CreateTulis : MonoBehaviour
{
    public class ContentBelajar
    {
        public string Meaning { get; set; }
       /* public Sprite guratanl { get; set; }
        public Sprite guratan2 { get; set; }
        public Sprite guratan3 { get; set; }
        public Sprite guratan4 { get; set; }
        public Sprite guratan5 { get; set; }
        public Sprite guratan6 { get; set; }
        public Sprite guratan7 { get; set; }
        public Sprite guratan8 { get; set; }
        public Sprite guratan9 { get; set; }
        public Sprite guratan10 { get; set; }
        public Sprite guratanl1 { get; set; }
        public Sprite guratan12 { get; set; }
        public Sprite guratanl3 { get; set; }
        public Sprite guratan14 { get; set; }
        public Sprite guratanl5 { get; set; }
        public Sprite guratan16 { get; set; }
        public Sprite guratanl7 { get; set; }
        public Sprite guratan18 { get; set; }
        public Sprite guratanl9 { get; set; }
        public Sprite guratan20 { get; set; }
        public Sprite guratan2l { get; set; }*/
        public VideoClip video { get; set; }
    }
   /* [System.Serializable]
    public class guratanP
    {
        public Sprite[] gurat;
    }*/
    [Header("Content")]
    //[SerializeField] ContentBelajar[] arrayContent;
    [SerializeField] string[] Meaning;
    //[SerializeField] guratanP[] guratan;
    [SerializeField] VideoClip[] video;

    int SizeContent;
    int IndexContent;

    [Header("Holder")]
   // [SerializeField] Image[] GuratanHolder;
    [SerializeField] Text MeaningHolder;
    [SerializeField] VideoPlayer VideoHolder;

    [Header("Button")]
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject NextButton;
    [SerializeField] GameObject PrevButton;

    // Use this for initialization
    void Start()
    {
        SizeContent = Meaning.Length;
        IndexContent = 0;

        insertContent();
    }

    public void insertContent()
    {

        /*for (int i = 0; i <= GuratanHolder.GetUpperBound(0); i++)
        {
            //Debug.Log(i);
            Color color = GuratanHolder[i].color;
            if (guratan[IndexContent].gurat[i] == null)
            {                
                color.a = 0;               
            }
            else
            {
                color.a = 255;                
            }
            GuratanHolder[i].color = color;
            GuratanHolder[i].sprite = guratan[IndexContent].gurat[i];
        }   */    
        MeaningHolder.text = Meaning[IndexContent];

        //sound
        VideoHolder.Stop();
        VideoHolder.clip = video[IndexContent];
        PauseButton.SetActive(true);
        VideoHolder.Play();
    }
    // Update is called once per frame
    void Update()
    {
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
    }

    public void VideoPlayPause()
    {
        if (VideoHolder.isPlaying)
        {
            PlayButton.SetActive(true);
            PauseButton.SetActive(false);
            VideoHolder.Pause();
            
        }
        else if (!VideoHolder.isPlaying)
        {
            PauseButton.SetActive(true);
            PlayButton.SetActive(false); 
            VideoHolder.Play();
        }
    }

    public void NextContent()
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
    }
}