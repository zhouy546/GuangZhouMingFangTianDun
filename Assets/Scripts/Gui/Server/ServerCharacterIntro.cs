using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerCharacterIntro : I_Image
{
    public I_Text DebugText;

    public int TickTime;


   
    public string videoUrl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Show()
    {
        base.Show();
        DebugText.Show();
        SetTick();
        
        PlayVideo();
    }

    public override void Hide()
    {
        base.Hide();
        DebugText.Hide();

    }

    public override void SetTick()
    {
        if (GameManager.GetServerPlayer().isLocalPlayer)
        {
            Tick tick = GameManager.instance.GetComponent<Tick>();

            tick.DefaultCountDonwTime = TickTime;
            tick.CurrentCountDonwTime = TickTime;
        }
    }

    public override void setVideoUrl(string s)
    {
        videoUrl = s;
    }

    public override void PlayVideo()
    {
        Debug.Log("Running");
        if (videoUrl != "")
        {
            ServerMediaCtr.instance.SetVideoColorAlpha(255f);
            ServerMediaCtr.instance.PlayVideo(videoUrl);
        }
        else
        {
            ServerMediaCtr.instance.SetVideoColorAlpha(0f);
        }
    }

}
