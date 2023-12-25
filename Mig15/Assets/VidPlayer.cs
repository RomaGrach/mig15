using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{

    [SerializeField] string videoFileName;

    // Start is called before the first frame update
    void Start()
    {
        PlayVideo();
    }

    public void PlayVideo()
    {
        Debug.Log("зашел");
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
        else
        {
            Debug.Log("игнор");
        }

    }
}


