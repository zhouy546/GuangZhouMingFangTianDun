using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerQADotsCtr : MonoBehaviour
{
    public List<ServerQADotsNode> serverQADotsNodes = new List<ServerQADotsNode>();

    public string CurrentCorrectAnswer;

    public static ServerQADotsCtr instance;

    public Image Board;
    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDots()
    {

        for (int i = 0; i < 50; i++)
        {
            if (GameManager.kp_seatID_Answer[i].currentSelectAnswer == "F")
            {
                serverQADotsNodes[i].SetColor(Color.white);
            }
            else if(GameManager.kp_seatID_Answer[i].currentSelectAnswer== CurrentCorrectAnswer)
            {
                serverQADotsNodes[i].SetColor(Color.green);
            }
            else if(GameManager.kp_seatID_Answer[i].currentSelectAnswer != CurrentCorrectAnswer)
            {
                serverQADotsNodes[i].SetColor(Color.red);
            }
        }

    }

    public void Show()
    {
        foreach (var item in serverQADotsNodes)
        {
            item.Show();
        }

        Board.enabled = true;
    }

    public void Hide() {
        foreach (var item in serverQADotsNodes)
        {
            item.Hide();
        }

        Board.enabled = false;

    }
}
