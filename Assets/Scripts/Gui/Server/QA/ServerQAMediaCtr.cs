using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerQAMediaCtr : MonoBehaviour
{

    public MediaPlayer mediaPlayer;
    public DisplayUGUI displayUGUI;
    public string url = "10羊城天盾LED显示答题bg.mp4";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMedia() {
        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, url, false);

        mediaPlayer.Play();

        displayUGUI.color = new Color(255f, 255f, 255f, 255f);
    }

    public void StopMedia() {
        mediaPlayer.Stop();

        mediaPlayer.CloseVideo();

        displayUGUI.color = new Color(255f, 255f, 255f, 0f);
    }
}
