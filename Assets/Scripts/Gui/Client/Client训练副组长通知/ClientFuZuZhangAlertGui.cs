using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientFuZuZhangAlertGui : I_Image
{
    public I_Text DebugText;

    public List<int> ActiveIndex = new List<int>();

    public ClientFuZuZhangAlertGuiActive clientFuZuZhangAlertGuiActive;
    public ClientFuZuZhangAlertGuiDisable clientFuZuZhangAlertGuiDisable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Hide()
    {
        base.Hide();
        DebugText.Hide();
        clientFuZuZhangAlertGuiActive.Hide();
        clientFuZuZhangAlertGuiDisable.Hide();
    }

    public override void Show()
    {
        base.Show();
        DebugText.Show();
        ShowDisableOrActiveOne();
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void ShowDisableOrActiveOne()
    {
        if (IsShowFuZuZhangAlertGui())
        {
            clientFuZuZhangAlertGuiActive.Show();
            clientFuZuZhangAlertGuiDisable.Hide();
        }
        else
        {
            clientFuZuZhangAlertGuiActive.Hide();
            clientFuZuZhangAlertGuiDisable.Show();
        }
    }

    bool IsShowFuZuZhangAlertGui()
    {
        int LockDonwIndex = GameManager.instance.getCharacterByName(GameManager.GetCurrentLocalPlayer().name).SelectID;
        return ActiveIndex.Contains(LockDonwIndex);

    }
}
