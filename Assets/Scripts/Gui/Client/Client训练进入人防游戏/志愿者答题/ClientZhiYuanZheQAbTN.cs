using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientZhiYuanZheQAbTN : MonoBehaviour
{
    public ClientZhiYuanZheQAbTN clientZhiYuanZheQAbTN;

    public GameObject[] subGraph;

    public bool isRightAnswer;

    public bool isSelected;
    public Image AnswerImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        AnswerImage.color = Color.white;
        HideSub();
    }

    public bool getIsRightAnswer()
    {
        if (isSelected == isRightAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ShowRightAnswer()
    {
        if (isRightAnswer)
        {
            AnswerImage.color = Color.green;
        }
    }

    public void  OnClick() {


            isSelected = true;

        ShowSub();
        clientZhiYuanZheQAbTN.HideSub();
    }

    public void OnDisable()
    {
        HideSub();
    }

    public void  ShowSub()
    {
        foreach (var item in subGraph)
        {
            item.SetActive(true);
        }
    }

    public void HideSub()
    {
        foreach (var item in subGraph)
        {
            item.SetActive(false);
        }
        isSelected = false;
    }


}
