using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    public CalibrateDialogue calibrateDialogue;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Method to play a specific video based on index
    public void PlayVideo(int index)
    {
        if (index >= 0 && index < videoClips.Length)
        { 
            videoPlayer.clip = videoClips[index];
            videoPlayer.Play();
        }
        else
        {
            Debug.LogWarning("Invalid video index.");
        }
    }
}