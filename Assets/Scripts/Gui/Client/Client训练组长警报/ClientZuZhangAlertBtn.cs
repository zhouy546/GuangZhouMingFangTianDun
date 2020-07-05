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

    public string[] EvluationString;

    public string CurrentEvluationString;

    public bool isPassed;

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
        PassedTest();
    }

    public string[] getvluationString() {
        string[] tempString = new string[2];
        if (isPassed)
        {
            tempString[0] = isPassed.ToString();
            tempString[1] = CurrentEvluationString;

            return tempString;
        }
        else
        {
            NotPassedTest();

            tempString[0] = isPassed.ToString();
            tempString[1] = CurrentEvluationString;

            return tempString;
        }
    }

    public void PassedTest() {
        isPassed = true;
        CurrentEvluationString = EvluationString[0];
    }

    public void NotPassedTest() {
        isPassed = false;
        CurrentEvluationString = EvluationString[1];
    }

    public void ResetEvluation() {
        isPassed = false;
        CurrentEvluationString = "";
    }

    public void ResetMe()
    {
        m_btn.interactable = true;
    }
}
