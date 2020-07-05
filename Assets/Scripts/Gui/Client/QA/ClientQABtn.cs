using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientQABtn : I_Image
{
    public string ANSWER;
    public Button btn;
    public override void Awake()
    {
        base.Awake();
    }

    public override void Hide()
    {
        base.Hide();
        image.raycastTarget = false;

    }

    public override void Show()
    {
        base.Show();
        image.raycastTarget = true;

    }

    public void onBtnClick() {
        string S = "#" + GameManager.PADID + "_" + ANSWER;

        SendUPDData.instance.udp_Send(S, GameManager.ServerIp, GameManager.ServerUDPPort);
        Debug.Log("Sentupd");
        this.GetComponent<Button>().interactable = false;
        btn.interactable = false;


    }

}
