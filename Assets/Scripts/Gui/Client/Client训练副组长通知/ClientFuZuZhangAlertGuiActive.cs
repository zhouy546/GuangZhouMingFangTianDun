using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientFuZuZhangAlertGuiActive : I_Image
{
    public I_Text DebugText;

    public I_Image FuZuZhangBtn;

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
        FuZuZhangBtn.Hide();
    }

    public override void Show()
    {
        base.Show();
        DebugText.Show();
        FuZuZhangBtn.Show();
    }

    public override void Awake()
    {
        base.Awake();
    }


}
