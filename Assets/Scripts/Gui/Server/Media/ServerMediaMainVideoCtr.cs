using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerMediaMainVideoCtr : MonoBehaviour
{

    public MediaPlayer mediaPlayer;
    public DisplayUGUI ugui;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener<string>(EventDefine.PlayMainVideo, PlayVideo);
        EventCenter.AddListener(EventDefine.Stop, Stop);
        EventCenter.AddListener(EventDefine.VolumeDown, VolumeDown);
        EventCenter.AddListener(EventDefine.VolumeUp, VolumeUp);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo(string udp)
    {
        Debug.Log("PlayVideo");
        VideoInfo temp = GameManager.kp_udp_VideoInfo[udp];

        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, temp.url, false);

        mediaPlayer.Control.SetLooping(temp.isLoop);

        mediaPlayer.Play();

        ugui.color = new Color(255f, 255f, 255f, 255f);
    }

    public void VolumeUp()
    {
        float volume = mediaPlayer.Control.GetVolume() + 0.1f;
        volume = Mathf.Clamp01(volume);
        mediaPlayer.Control.SetVolume(volume);
    }

    public void VolumeDown()
    {
        float volume = mediaPlayer.Control.GetVolume() - 0.1f;
        volume = Mathf.Clamp01(volume);
        mediaPlayer.Control.SetVolume(volume);
    }

    public void Stop()
    {
        mediaPlayer.Stop();
        mediaPlayer.CloseVideo();

        SendUPDData.instance.udp_Send("1003", "127.0.0.1", 29010);

        ugui.color = new Color(255f, 255f, 255f, 0);

    }

    public void OnVideoFinished()
    {
        mediaPlayer.CloseVideo();
        SendUPDData.instance.udp_Send("1003","127.0.0.1", 29010);

        ugui.color = new Color(255f, 255f, 255f, 0);
    }
}
