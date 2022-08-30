using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SetVideoUrl : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    void Awake()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "game-demo.mp4");
    }
}
