using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerMediaMainVideoCtr : MonoBehaviour
{

    public MediaPlayer mediaPlayerGound;
    public DisplayUGUI Groundugui;

    public MediaPlayer mediaPlayerWall;
    public DisplayUGUI Wallugui;
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

        //地面播放
        Debug.Log("PlayVideo");
        VideoInfo temp = GameManager.kp_udp_VideoInfo[udp];

        mediaPlayerGound.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, temp.Groundurl, false);

        mediaPlayerGound.Control.SetLooping(temp.isLoop);

        mediaPlayerGound.Play();

        Groundugui.color = new Color(255f, 255f, 255f, 255f);

        //墙面播放
        mediaPlayerWall.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, temp.WallUrl, false);

        mediaPlayerWall.Control.SetLooping(temp.isLoop);

        mediaPlayerWall.Play();

        Wallugui.color = new Color(255f, 255f, 255f, 255f);

    }

    public void VolumeUp()
    {
        float volume = mediaPlayerGound.Control.GetVolume() + 0.1f;
        volume = Mathf.Clamp01(volume);
        mediaPlayerGound.Control.SetVolume(volume);
    }

    public void VolumeDown()
    {
        float volume = mediaPlayerGound.Control.GetVolume() - 0.1f;
        volume = Mathf.Clamp01(volume);
        mediaPlayerGound.Control.SetVolume(volume);
    }

    public void Stop()
    {

        //地面停止
        mediaPlayerGound.Stop();
        mediaPlayerGound.CloseVideo();

        SendUPDData.instance.udp_Send("1003", "127.0.0.1", 29010);

        Groundugui.color = new Color(255f, 255f, 255f, 0);

        //墙面停止
        mediaPlayerWall.Stop();
        mediaPlayerWall.CloseVideo();
        Wallugui.color = new Color(255f, 255f, 255f, 0);

    }

    public void OnVideoFinished()
    {
        mediaPlayerGound.CloseVideo();
        SendUPDData.instance.udp_Send("1003","127.0.0.1", 29010);

        Groundugui.color = new Color(255f, 255f, 255f, 0);

        mediaPlayerWall.CloseVideo();
        Wallugui.color = new Color(255f, 255f, 255f, 0);
    }
}
