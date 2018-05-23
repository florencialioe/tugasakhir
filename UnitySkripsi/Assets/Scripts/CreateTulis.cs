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
    [Header("Content")]
    //[SerializeField] ContentBelajar[] arrayContent;
    [SerializeField] string[] Meaning;
    [SerializeField] Sprite[] guratan1;
    [SerializeField] Sprite[] guratan2;
    [SerializeField] Sprite[] guratan3;
    [SerializeField] Sprite[] guratan4;
    [SerializeField] Sprite[] guratan5;
    [SerializeField] Sprite[] guratan6;
    [SerializeField] Sprite[] guratan7;
    [SerializeField] Sprite[] guratan8;
    [SerializeField] Sprite[] guratan9;
    [SerializeField] Sprite[] guratan10;
    [SerializeField] Sprite[] guratan11;
    [SerializeField] Sprite[] guratan12;
    [SerializeField] Sprite[] guratan13;
    [SerializeField] Sprite[] guratan14;
    [SerializeField] Sprite[] guratan15;
    [SerializeField] Sprite[] guratan16;
    [SerializeField] Sprite[] guratan17;
    [SerializeField] Sprite[] guratan18;
    [SerializeField] Sprite[] guratan19;
    [SerializeField] Sprite[] guratan20;
    [SerializeField] Sprite[] guratan21;
    [SerializeField] VideoClip[] video;


    int SizeContent;
    int IndexContent;

    [Header("Holder")]
    [SerializeField] Image guratan1Holder;
    [SerializeField] Image guratan2Holder;
    [SerializeField] Image guratan3Holder;
    [SerializeField] Image guratan4Holder;
    [SerializeField] Image guratan5Holder;
    [SerializeField] Image guratan6Holder;
    [SerializeField] Image guratan7Holder;
    [SerializeField] Image guratan8Holder;
    [SerializeField] Image guratan9Holder;
    [SerializeField] Image guratan10Holder;
    [SerializeField] Image guratan11Holder;
    [SerializeField] Image guratan12Holder;
    [SerializeField] Image guratan13Holder;
    [SerializeField] Image guratan14Holder;
    [SerializeField] Image guratan15Holder;
    [SerializeField] Image guratan16Holder;
    [SerializeField] Image guratan17Holder;
    [SerializeField] Image guratan18Holder;
    [SerializeField] Image guratan19Holder;
    [SerializeField] Image guratan20Holder;
    [SerializeField] Image guratan21Holder;
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
        guratan1Holder.sprite = guratan1[IndexContent];
        guratan2Holder.sprite = guratan2[IndexContent];
        guratan3Holder.sprite = guratan3[IndexContent];
        guratan4Holder.sprite = guratan4[IndexContent];
        guratan5Holder.sprite = guratan5[IndexContent];
        guratan6Holder.sprite = guratan6[IndexContent];
        guratan7Holder.sprite = guratan7[IndexContent];
        guratan8Holder.sprite = guratan8[IndexContent];
        guratan9Holder.sprite = guratan9[IndexContent];
        guratan10Holder.sprite = guratan10[IndexContent];
        guratan11Holder.sprite = guratan11[IndexContent];
        guratan12Holder.sprite = guratan12[IndexContent];
        guratan13Holder.sprite = guratan13[IndexContent];
        guratan14Holder.sprite = guratan14[IndexContent];
        guratan15Holder.sprite = guratan15[IndexContent];
        guratan16Holder.sprite = guratan16[IndexContent];
        guratan17Holder.sprite = guratan17[IndexContent];
        guratan18Holder.sprite = guratan18[IndexContent];
        guratan19Holder.sprite = guratan19[IndexContent];
        guratan20Holder.sprite = guratan20[IndexContent];
        guratan21Holder.sprite = guratan21[IndexContent];
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
