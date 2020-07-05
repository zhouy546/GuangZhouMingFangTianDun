using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientShuSanActiveGameSubmit : MonoBehaviour
{
    public Button button;
    public Image image;

    public ClientShuSanActiveBtn[] BTNS = new ClientShuSanActiveBtn[2];

    public string eveluateString;

    public string[] DefaulteveluateStrings = new string[1];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        if (isAnswercorrect())
        {
            //回答正确
            button.interactable = false;
            image.raycastTarget = false;
        }
        else
        {
            eveluateString = DefaulteveluateStrings[0];

            foreach (var item in BTNS)
            {
                item.ShowRightAnswer();
            }
        }

    }

    public bool isAnswercorrect() {
        for (int i = 0; i < BTNS.Length; i++)
        {
          if(!BTNS[i].getIsRightAnswer())
            {
                return false;
            }
        }

        return true;
    }

    public void OnDisable()
    {
        Debug.Log("引导员界面关闭");
        button.interactable = true;
        image.raycastTarget = true; ;
    }

    public void OnEnable()
    {
        Debug.Log("引导员界面显示");
        button.interactable = true;
        image.raycastTarget = true; ;

        eveluateString = "";
    }
}
