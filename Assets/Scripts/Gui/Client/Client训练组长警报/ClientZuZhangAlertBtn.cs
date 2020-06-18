using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientZuZhangAlertBtn : I_Image
{
  //  public I_Text BoardCaseText;

    public Button m_btn;

    //private string BoardCastTest = "广播";

    //private string AfterBoardCastTest = "广播已发出";



    public Image[] Graphs;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShowGraph()
    {
        foreach (var item in Graphs)
        {
            item.enabled = true;
        }
    }

    private void HideGraph()
    {
        foreach (var item in Graphs)
        {
            item.enabled = false;
        }
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Hide()
    {
        base.Hide();
        image.raycastTarget = false;
        ResetMe();
        HideGraph();
    }

    public override void Show()
    {
        base.Show();
        image.raycastTarget = true;
        ResetMe();
        ShowGraph();
    }

    public void OnBtnClick()
    {
        m_btn.interactable = false;
    }

    public void ResetMe()
    {
        m_btn.interactable = true;
    }
}
