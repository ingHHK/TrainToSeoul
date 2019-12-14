using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    VideoPlayer vPlayer;
    int index;

    // Start is called before the first frame update
    void Awake(){
        vPlayer = GetComponent<VideoPlayer>();
        vPlayer.loopPointReached += OnMovieFinished;
        index = SceneManager.GetActiveScene().buildIndex;
    }

    void OnMovieFinished(VideoPlayer player){
        player.Stop();
        
        if(index < 11)
            SceneManager.LoadScene(++index);
        else
            SceneManager.LoadScene(0);
    }
}
