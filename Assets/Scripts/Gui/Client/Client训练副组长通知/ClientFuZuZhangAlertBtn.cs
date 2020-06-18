using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientFuZuZhangAlertBtn : I_Image
{
    //public I_Text BoardCaseText;

    public Button m_btn;

    //private string BoardCastTest = "各人员就位";

    //private string AfterBoardCastTest = "通知已经发出";
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
        image.raycastTarget = false;
       // BoardCaseText.Hide();
        ResetMe();
    }

    public override void Show()
    {
        base.Show();
        image.raycastTarget = true;
     //   BoardCaseText.Show();
        ResetMe();
    }

    public void OnBtnClick()
    {
    //    BoardCaseText.image.text = AfterBoardCastTest;
        m_btn.interactable = false;
    }

    public void ResetMe()
    {
  //      BoardCaseText.image.text = BoardCastTest;
        m_btn.interactable = true;
    }
}
