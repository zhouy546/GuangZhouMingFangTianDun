using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerQA : I_Image
{
    public I_Text debugText;
    public List<ServerQANode> serverQANodes = new List<ServerQANode>();

    public List<int> questionID = new List<int>();

    public static ServerQA instance;
    // Start is called before the first frame update
    public    override void Awake()
    {
        base.Awake();
        instance = this;
    }


    void Start()
    {
        EventCenter.AddListener(EventDefine.INI, ini);
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void ini()
    {
        questionID = M_Utility.GetRandom(0, GameManager.kp_id_qAinfos.Count-1, serverQANodes.Count);

        foreach (var item in questionID)
        {
            string question = GameManager.kp_id_qAinfos[item].question;
            int RightAnswer = GameManager.kp_id_qAinfos[item].RightAnswer;
            string[] A1 = GameManager.kp_id_qAinfos[item].A1;

            serverQANodes[questionID.IndexOf(item)].SetA1Text(A1);
            serverQANodes[questionID.IndexOf(item)].SetQuestionText(question);
            serverQANodes[questionID.IndexOf(item)].SetRightAnswer(RightAnswer);
        }
   
    }


    public void ResetQA() {
        foreach (var item in serverQANodes)
        {
            item.StopCountDown();

            item.Hide();
        }


        foreach (var item in GameManager.kp_seatID_Answer.Values)
        {
            item.reset();
        }

        Hide();

        ini();

        ServerQAScoreboard.instance.Hide();
    }

    public override void Hide()
    {
        base.Hide();
        debugText.Hide();
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        serverQANodes[0].Show();

    }
}
