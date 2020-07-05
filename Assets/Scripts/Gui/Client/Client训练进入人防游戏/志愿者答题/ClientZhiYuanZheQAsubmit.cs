using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZhiYuanZheQAsubmit : MonoBehaviour
{
   public   ClientZhiYuanZheBaseGameActive clientZhiYuanZheBaseGameActive;

    public ClientZhiYuanZheQAbTN[] BTNS = new ClientZhiYuanZheQAbTN[2];

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

    public void OnClick()
    {
        if (isAnswercorrect())
        {
            clientZhiYuanZheBaseGameActive.GoToStage2();

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

    public bool isAnswercorrect()
    {
        for (int i = 0; i < BTNS.Length; i++)
        {
            if (!BTNS[i].getIsRightAnswer())
            {
                return false;
            }
        }

        return true;
    }
}
