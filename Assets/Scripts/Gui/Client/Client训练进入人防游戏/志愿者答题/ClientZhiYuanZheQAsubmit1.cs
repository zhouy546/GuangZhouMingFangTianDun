using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientZhiYuanZheQAsubmit1 : MonoBehaviour
{
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

    public void OnDisable()
    {
        this.GetComponent<Button>().interactable = true;

    }

    public void OnClick()
    {
        if (isAnswercorrect())
        {
            this.GetComponent<Button>().interactable = false;
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
