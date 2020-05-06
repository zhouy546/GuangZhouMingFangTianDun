using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZuZhangAlertBtn : I_Image
{
    public I_Text BoardCaseText;

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
        image.raycastTarget = false;
        BoardCaseText.Hide();
    }

    public override void Show()
    {
        base.Show();
        image.raycastTarget = true;
        BoardCaseText.Show();

    }
}
