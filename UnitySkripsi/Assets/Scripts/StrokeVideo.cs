using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StrokeVideo : MonoBehaviour
{

    public RawImage image;
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
    }
}