using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZuZhangAlert : I_Image
{
    public ClientZuZhangAlertActiveGui clientZuZhangAlertActiveGui;
    public ClientZuZhangAlertDisableGui clientZuZhangAlertDisableGui;

    public I_Text DebugText;

    public List<int> ActiveIndex = new List<int>();

    public ClientZuZhangAlertBtn clientZuZhangAlertBtn;

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     bool IsShowZuZhangAlertGui()
    {
        int LockDonwIndex = GameManager.instance.getCharacterByName(GameManager.GetCurrentLocalPlayer().name).SelectID;
        return ActiveIndex.Contains(LockDonwIndex);
    
    }

    public override void Hide()
    {
        base.Hide();
        clientZuZhangAlertActiveGui.Hide();
        clientZuZhangAlertDisableGui.Hide();
        DebugText.Hide();

    }

    public override void Show()
    {
        base.Show();
        DebugText.Show();
        ShowDisableOrActiveOne();
    }

    public override void ShowDisableOrActiveOne()
    {
        if (IsShowZuZhangAlertGui())
        {
            clientZuZhangAlertActiveGui.Show();
            clientZuZhangAlertDisableGui.Hide();
        }
        else
        {
            clientZuZhangAlertActiveGui.Hide();
            clientZuZhangAlertDisableGui.Show();
        }
    }

    public override string[] GetEvluationString() {

        foreach (var item in clientZuZhangAlertBtn.getvluationString())
        {
            Debug.Log(item);
        }

        return  clientZuZhangAlertBtn.getvluationString();
    }

    public override void ResetEvluationString() {
        clientZuZhangAlertBtn.ResetEvluation();
    }
}
