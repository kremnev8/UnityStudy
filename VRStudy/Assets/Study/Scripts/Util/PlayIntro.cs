using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayIntro : MonoBehaviour
{
    public VideoPlayer player;
    public int gameScene;
    
    private bool done;
    
    void Start ()
    {
        player = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (done) return;
        if (player.frame == (long)player.clip.frameCount - 1)
        {
            done = true;
            SceneManager.LoadScene (gameScene);
        }
    }
}
