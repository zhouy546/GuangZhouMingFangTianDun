using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZuZhangAlert : I_Image
{
    public ClientZuZhangAlertActiveGui clientZuZhangAlertActiveGui;
    public ClientZuZhangAlertDisableGui clientZuZhangAlertDisableGui;

    public I_Text DebugText;

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
    public override void Hide()
    {
        base.Hide();
        //clientZuZhangAlertActiveGui.Hide();
        //clientZuZhangAlertDisableGui.Hide();
        DebugText.Hide();

    }

    public override void Show()
    {
        base.Show();
        DebugText.Show();
    }

    public override void ShowDisableOrActiveOne(bool IsActiveState)
    {
        if (IsActiveState)
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
}
