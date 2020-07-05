using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientCancelAlert : I_Image
{
    public I_Text debugText;

    public ClientZuZhangReleaseAlertActiveGui clientZuZhangReleaseAlertActiveGui;
    public ClientZuZhangReleaseAlertDisableGui clientZuZhangReleaseAlertDisableGui;

    public List<int> ActiveIndex = new List<int>();

    public ClientJieChuFangKongBtn clientJieChuFangKongBtn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    bool IsShow()
    {
        int LockDonwIndex = GameManager.instance.getCharacterByName(GameManager.GetCurrentLocalPlayer().name).SelectID;
        return ActiveIndex.Contains(LockDonwIndex);

    }

    public override void Hide()
    {
        base.Hide();
        clientZuZhangReleaseAlertActiveGui.Hide();
        clientZuZhangReleaseAlertDisableGui.Hide();
        debugText.Hide();

    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        ShowDisableOrActiveOne();
    }

    public override void ShowDisableOrActiveOne()
    {
        if (IsShow())
        {
            clientZuZhangReleaseAlertActiveGui.Show();
            clientZuZhangReleaseAlertDisableGui.Hide();
        }
        else
        {
            clientZuZhangReleaseAlertActiveGui.Hide();
            clientZuZhangReleaseAlertDisableGui.Show();
        }
    }


    public override string[] GetEvluationString()
    {
        return clientJieChuFangKongBtn.getvluationString();
    }

    public override void ResetEvluationString()
    {
        clientJieChuFangKongBtn.ResetEvluation();
    }
}
