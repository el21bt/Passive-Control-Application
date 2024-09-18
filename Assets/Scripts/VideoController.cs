using System;
using UnityEngine;
using UnityEngine.Video;


//plays video dpeending on index of calibration process
public class VideoController : MonoBehaviour
{
    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    public CalibrateDialogue calibrateDialogue;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.clip = videoClips[0];
    }

    // Method to play a specific video based on index
    public void PlayVideo(int index)
    {
        //print(index);
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