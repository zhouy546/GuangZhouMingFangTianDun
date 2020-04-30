﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientTakePhoto : I_Image
{
    private bool camAvailable;
    private WebCamTexture frontcam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    public Button OpenCameraBtn;
    public Button CloseCameraBtn;

    public I_Image next;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("初始化摄像机按钮");

            Debug.Log("添加摄像机按钮事件");
            OpenCameraBtn.onClick.AddListener(initializedCam);
            CloseCameraBtn.onClick.AddListener(TurnOffCam);

    }


    public void initializedCam()
    {
        Debug.Log("尝试初始化摄像头");
        Player player = GameManager.GetCurrentLocalPlayer();
        if (!player.isServer && player.isLocalPlayer)
        {
            Debug.Log("初始化摄像头");
            defaultBackground = background.texture;
            WebCamDevice[] devices = WebCamTexture.devices;
            if (devices.Length == 0)
            {
                camAvailable = false;
                return;
            }

            for (int i = 0; i < devices.Length; i++)
            {
                if (devices[i].isFrontFacing)
                {
                    frontcam = new WebCamTexture(devices[i].name, Screen.width / 10, Screen.height / 10);

                }
            }

            if (frontcam == null)
            {
                Debug.Log("找不到前置摄像头");
            }

            frontcam.Play();
            background.texture = frontcam;

            camAvailable = true;
        }
    }

    public void TurnOffCam()
    {
        Player player = GameManager.GetCurrentLocalPlayer();
        if (!player.isServer && player.isLocalPlayer)
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            if (devices.Length == 0)
            {
                return;
            }
            frontcam.Stop();
            camAvailable = false;



            byte[] textureData = M_Utility.TextureToTexture2D(background.texture).EncodeToJPG();

            Debug.Log(player.name + "玩家将图片同步到服务器");

            player.CmdUpdateCharacterPhoto(textureData, player.name);

            next.Show();//显示选人画面
        }
    }



    public override void Hide()
    {
        base.Hide();
        OpenCameraBtn.gameObject.SetActive(false);
        CloseCameraBtn.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        background.gameObject.SetActive(true);

        OpenCameraBtn.gameObject.SetActive(true);
        CloseCameraBtn.gameObject.SetActive(true);
    }

    public override void Awake()
    {
        base.Awake();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
