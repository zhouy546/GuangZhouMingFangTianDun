using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZuZhangAlertActiveGui : I_Image
{
    public I_Text debugText;
    public I_Image ZuZhangAlertBtn;
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

    public override void Hide()
    {
        base.Hide();
        debugText.Hide();
        ZuZhangAlertBtn.Hide();
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        ZuZhangAlertBtn.Show();

    }
}
