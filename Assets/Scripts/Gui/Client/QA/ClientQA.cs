using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientQA : I_Image
{
    public I_Text debugText;

    public I_Image btnA;
    public I_Image btnB;


    public override void Awake()
    {
        base.Awake();
    }

    public override void Hide()
    {
        base.Hide();
        debugText.Hide();
        btnA.Hide();
        btnB.Hide();
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        btnA.Show();
        btnB.Show();

    }

    public void resetbtn() {
        btnA.GetComponent<Button>().interactable = true;
        btnB.GetComponent<Button>().interactable = true;
    }
}
