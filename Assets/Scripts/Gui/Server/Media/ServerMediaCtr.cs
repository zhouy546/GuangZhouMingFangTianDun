using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerMediaCtr : MonoBehaviour
{
    public MediaPlayer mediaPlayer;

    public DisplayUGUI displayUGUI; 

    public static ServerMediaCtr instance;

    private void Awake()
    {
        EventCenter.AddListener(EventDefine.XunLianPause, pauseVideo);
        EventCenter.AddListener(EventDefine.XunLianContinue, ContinueVideo);
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pauseVideo() {
        mediaPlayer.Pause();
    }

    public void ContinueVideo()
    {
        mediaPlayer.Play();
    }

    public void PlayVideo(string path) {
        SetVideoColorAlpha(255f);
        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, path, true);
    }

    public void SetVideoColorAlpha(float a)
    {
     //   Debug.Log(a);
        displayUGUI.color = new Color(displayUGUI.color.r, displayUGUI.color.g, displayUGUI.color.b, a);
    }


    public void OnVideoFinished()
    {
        SetVideoColorAlpha(0);
    }
    

    public void StopVideo()
    {
        SetVideoColorAlpha(0);
        mediaPlayer.Stop();
    }
}
