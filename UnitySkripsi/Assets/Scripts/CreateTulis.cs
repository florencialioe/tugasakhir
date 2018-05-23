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
        public Sprite guratanl { get; set; }
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
        public Sprite guratan2l { get; set; }
        public VideoClip video { get; set; }

    }
    [System.Serializable]
    public class guratanP
    {
        public Sprite[] gurat;
    }
    [Header("Content")]
    //[SerializeField] ContentBelajar[] arrayContent;
    [SerializeField] string[] Meaning;
    [SerializeField] guratanP[] guratan;
    [SerializeField] VideoClip[] video;


    int SizeContent;
    int IndexContent;

    [Header("Holder")]
    [SerializeField] Image[] GuratanHolder;
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
        SizeContent = Meaning.GetUpperBound(0);
        IndexContent = 0;

        insertContent();
    }

    public void insertContent()
    {

        for (int i = 0; i <= GuratanHolder.GetUpperBound(0); i++)
        {
            //Debug.Log(i);
            if (guratan[IndexContent].gurat[i] == null)
            {
                Color color = GuratanHolder[i].color;
                color.a = 0;
                GuratanHolder[i].color = color;
            }
            GuratanHolder[i].sprite = guratan[IndexContent].gurat[i];
        }       
        MeaningHolder.text = Meaning[IndexContent];

        //sound
        VideoHolder.Stop();
        VideoHolder.clip = video[IndexContent];
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

    public void Video()
    {
       VideoHolder.Stop();
       VideoHolder.Play();
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
    /*public RawImage image;
    public GameObject playIcon;

    public VideoClip videoToPlay;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    private bool isPaused = false;
    private bool firstRun = true;

    IEnumerator playVideo()
    {
        playIcon.SetActive(false);
        firstRun = false;
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        videoPlayer.playOnAwake = false;

        videoPlayer.source = VideoSource.VideoClip;

        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        image.texture = videoPlayer.texture;

        videoPlayer.Play();

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {

            Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;

        }

        Debug.Log("Done Playing Video");

    }

    public void PlayPause()
    {
        if (!firstRun && !isPaused)
        {
            videoPlayer.Pause();
            playIcon.SetActive(true);
            isPaused = true;
        }
        else if (!firstRun && isPaused)
        {
            videoPlayer.Play();
            playIcon.SetActive(false);
            isPaused = false;
        }
        else
        {
            StartCoroutine(playVideo());
        }
    }*/
}
