
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

                PlayerChangeState(GameState.训练演习选人);

            }
            else if (dataTest == "1001")
            {
                //PlayerChangeState(State.YanXunState);
                //GameManager.GetServerPlayer().SetServerYanYunState(YanYun.PlayerSelectCharacterState);

            }
            else if (dataTest == "1002")
            {
                //PlayerChangeState(State.QAState);
            }
            else if (dataTest == "1003")
            {
                PlayerChangeState(GameState.默认界面);
            }
        }

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

    

}
