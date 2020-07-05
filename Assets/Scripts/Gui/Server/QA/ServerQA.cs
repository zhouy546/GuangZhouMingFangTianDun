using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerQA : I_Image
{
    public I_Text debugText;
    public List<ServerQANode> serverQANodes = new List<ServerQANode>();

    public List<int> questionID = new List<int>();

    public static ServerQA instance;

    public GameObject InfoGameObject;

    public GameObject g_Graphs;

    public GameObject GroundBGImage;

    public ServerQAMediaCtr QAMediaCtr;

    public QATickTextUpdate qATickTextUpdate;
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
        InfoGameObject.SetActive(false);
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
        InfoGameObject.SetActive(false);
        ServerQASoundManager.instance.StopBgm();
        QAMediaCtr.StopMedia(); ;

        QATickTextUpdate.instance.Hide();
    }

    public override void Hide()
    {
        base.Hide();
        debugText.Hide();
        InfoGameObject.SetActive(false);
        QAMediaCtr.StopMedia();

        QATickTextUpdate.instance.Hide();

        g_Graphs.SetActive(false);

        GameManager.IsWenDaPlaying = false;

        StopAllCoroutines();

        GroundBGImage.SetActive(false);

    }

    public override void Show()
    {
        base.Show();

        InfoGameObject.SetActive(true);
        QAMediaCtr.PlayMedia();

        g_Graphs.SetActive(true);

        ServerQASoundManager.instance.PlayBGM();

        StartCoroutine(AutoJump());

        GroundBGImage.SetActive(true);

    }

    IEnumerator AutoJump() {
        yield return new WaitForSeconds(15f);

        SendUPDData.instance.udp_Send("1001", "127.0.0.1", 29010);
    }

    public void ShowMainQuestion()
    {
        GameManager.IsWenDaPlaying = true;


        debugText.Show();
        serverQANodes[0].Show();

        InfoGameObject.SetActive(false);
        QATickTextUpdate.instance.Show();



    }
}
