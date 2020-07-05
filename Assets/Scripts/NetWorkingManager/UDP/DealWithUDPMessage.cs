
//*********************❤*********************
// 
// 文件名（File Name）：	DealWithUDPMessage.cs
// 
// 作者（Author）：			LoveNeon
// 
// 创建时间（CreateTime）：	Don't Care
// 
// 说明（Description）：	接受到消息之后会传给我，然后我进行处理
// 
//*********************❤*********************

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DealWithUDPMessage : NetworkBehaviour
{



    public static DealWithUDPMessage instance;
    // public GameObject wellMesh;
    private string dataTest;


    //private static bool isInScreenProtect=true;


    //public LogoWellCtr logoWellCtr;
    //private bool enterTrigger, exitTrigger;
    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="_data"></param>
    [Server]
    public void MessageManage(string _data)
    {
    //    Debug.Log("DEALWITH MSG " + _data);
        if (_data != "")
        {

            dataTest = _data;
            Debug.Log(dataTest);
            if (dataTest == "1000")
            {
                GameManager.GetServerPlayer().Istick = false;
                ResetSyncVal(GameState.默认界面);
                PlayerChangeState(GameState.角色介绍);

            }
            else if (GameManager.kp_udp_VideoInfo.ContainsKey(dataTest))
            {
                ResetSyncVal(GameState.默认界面);
                PlayerChangeState(GameState.默认界面);

                EventCenter.Broadcast<string>(EventDefine.PlayMainVideo, dataTest);
            }
            else if(dataTest == "1001")
            {
                if (GameManager.instance.getCharacterByName(GameManager.GetServerPlayer().name).gameState == GameState.问答&&GameManager.IsWenDaPlaying ==false)
                {
                    ServerQA.instance.ShowMainQuestion();
                }
            }

            else if (dataTest == "1002")
            {
                ResetSyncVal(GameState.默认界面);
                PlayerChangeState(GameState.问答);
            }
            else if (dataTest == "1003")
            {
                ResetSyncVal(GameState.默认界面);
                PlayerChangeState(GameState.默认界面);
            }

            else if(dataTest == "pause")
            {

                if (GameManager.isPause)
                {
                    EventCenter.Broadcast(EventDefine.XunLianContinue);
                }
                else
                {
                    EventCenter.Broadcast(EventDefine.XunLianPause);
                }

                GameManager.isPause = !GameManager.isPause;

            }

            else if (dataTest == GameManager.VolumeDownUDP)
            {
                EventCenter.Broadcast(EventDefine.VolumeUp);
            }

            else if (dataTest == GameManager.VolumeUpUDP) {
                EventCenter.Broadcast(EventDefine.VolumeDown);
            }

            else if (dataTest == GameManager.StopUdp)
            {
                EventCenter.Broadcast(EventDefine.Stop);
            }

                char first = dataTest[0];

            if (first == '#')
            {
                string tempA = dataTest.Trim('#');
                int seatID = int.Parse(dealwithAnswer(tempA)[0]);
                string  Answer = dealwithAnswer(tempA)[1];
                GameManager.kp_seatID_Answer[seatID].setCurrentAnswer(Answer);

            }
        }

    }


    private string[] dealwithAnswer(string s) {
        string[] temp = new string[2];

        temp=s.Split('_');

        return temp;
    }


    [Server]
    public void PlayerChangeState(GameState _gameStates)
    {

        GameManager.GetServerPlayer().ServerSetState(_gameStates);
    }

    private void Awake()
    {

    }
    
    public IEnumerator Initialization() {
        if (instance == null)
        {
            instance = this;
        }
        yield return new  WaitForSeconds(0.01f);
    }

    public void Start()
    {

    }


    private void Update()
    {


        //Debug.Log("数据：" + dataTest);  
    }



    public void ResetSyncVal(GameState _gameState)
    {
        foreach (var item in GameManager.players)
        {
            GameManager.instance.SetCharacterLockedVal(item.Key, false);
            GameManager.instance.SetCharacterSelectIDVal(item.Key, -1);
            GameManager.instance.SetCharacterStateVal(item.Key, _gameState);
        }

       GameManager.GetServerPlayer().CmdServerPlayerResetChange();

        GameManager.instance.tick.ResetEvent();

        ServerMediaCtr.instance.StopVideo();

        ServerQA.instance.ResetQA();

        EventCenter.Broadcast(EventDefine.Stop);

        MapAlertCtr.instance.StopGroundVideo();
    }


    

}
