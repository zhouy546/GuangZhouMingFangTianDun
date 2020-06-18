using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ServerQANode : I_Image
{
    public Text QuestionText;
    public Text[] A1text;


    public string Question;
    public string[] A1 = new string[2];
    public int RightAnswer;

    public ServerQANode next;

    private int QuestionWaitTime=10;

    List<string> topPlayer = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.INI, Ini);
    }


    public void Ini()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuestionText(string s)
    {
        Question = s;
        QuestionText.text = s;

    }

    public void SetA1Text(string[] s)
    {
        A1 = s;
        for (int i = 0; i < A1.Length; i++)
        {
            A1text[i].text = s[i];  
        }
    }

    public void SetRightAnswer( int _rightAnswer)
    {
        RightAnswer = _rightAnswer;
            
     }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Hide()
    {
        base.Hide();
    }

    public override void Show()
    {
        resetClientQAbtn();

        base.Show();

        StartCoroutine(CountDown());
    }

    private void resetClientQAbtn() {
        if (GameManager.GetServerPlayer().isLocalPlayer)
        {
            Debug.Log("重置客户端答题按钮");
            GameManager.GetServerPlayer().RpcResetLocalPlayerQAbtn();
        }
    }

    private void UpdateClient()
    {

    }

    IEnumerator CountDown()
    {
        QuestionWaitTime--;
        yield return new WaitForSeconds(1f);
        if (QuestionWaitTime <= 0)
        {
            if (next != null)
            {
                A1text[RightAnswer].color = Color.green;


                yield return new WaitForSeconds(5);

                A1text[RightAnswer].color = Color.white;
                next.Show();
                Hide();
                QuestionWaitTime = 10;

                //结算所有玩家是否正确
                UpdateAnswer();

            }
            else
            {
                Hide();
                //最后结算所有玩家最高分，并且显示
                ServerQAScoreboard.instance.Show();
                topPlayer = getTopPlayerScore();
                string s="";
                foreach (var item in topPlayer)
                {
                    s =s+ item + "&";
                }
                ServerQAScoreboard.instance.SetText(s);

                foreach (var item in GameManager.kp_seatID_Answer)
                {
                    item.Value.reset();
                }
            }
        }
        else
        {
            StartCoroutine(CountDown());
        }
    }

    private string converAnswer()
    {
        if (RightAnswer == 0)
        {
            return "A";
        }else if (RightAnswer == 1)
        {
            return "B";
        }
        else
        {
            return "F";
        }
    }


    public void StopCountDown()
    {
        StopAllCoroutines();
    }



    List<string> getTopPlayerScore()
    {
        int temp = 0;
        Dictionary<int, int> kp_seatid_score = new Dictionary<int, int>();

        List<string> top3 = new List<string>();
        for (int i = 0; i < GameManager.kp_seatID_Answer.Count; i++)
        {
     //       Debug.Log(GameManager.kp_seatID_Answer[i].currentScore);

            kp_seatid_score.Add(i, GameManager.kp_seatID_Answer[i].currentScore);
        }

        var dicSort = from objDic in kp_seatid_score orderby objDic.Value descending select objDic;

        foreach (KeyValuePair<int, int> kvp in dicSort)
        {
            if (temp < 3)
            {
                string seatid = kvp.Key.ToString();
                string score = kvp.Value.ToString();

                string s = seatid + "_" + score;
                top3.Add(s);
            }
            temp++;
        }

        return top3;


    }



    void UpdateAnswer()
    {
        for (int i = 0; i < GameManager.kp_seatID_Answer.Count; i++)
        {
            if (GameManager.kp_seatID_Answer[i].currentSelectAnswer == converAnswer())
            {
                GameManager.kp_seatID_Answer[i].GainScore();
            }
        }

        foreach (var item in GameManager.kp_seatID_Answer)
        {
            item.Value.currentSelectAnswer = "F";
        }
    }

}
