using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{

    public Sprite PlayerPhoto;
    public List<LinkedListYanXiState> linkedListYanXiStates = new List<LinkedListYanXiState>();

    public List<GameState> XunLiangameStates = new List<GameState>();

    //public LinkedListYanXiState FirstlinkedListYanXiState;

    public bool Istick =false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(initi());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(GameManager.instance.getCharacterByName(this.name).gameState);
        }

    }
    public IEnumerator initi()
    {
        yield return new WaitForSeconds(0.5f);

        if (isServer)
        {
            if (isLocalPlayer) {
                GameManager.instance.IniCharacter(0, false, this.name, GameState.默认界面);
                Debug.Log("-------------------添加服务器玩家进入syncCharacter---------------------");

                Debug.Log("------------初始化训练状态链表--------------------");
                IniXunLianLinkedList();

            }
            else
            {
                GameState gameState = GameManager.instance.getCharacterByName(GameManager.GetServerPlayer().name).gameState;
                GameManager.instance.IniCharacter(0, false, this.name, gameState);
            }

        }



        if (isServer && isLocalPlayer)
        {
            Debug.Log("如果是服务器那就打开服务器默认界面");
            ServerCanvasCtr.instance.Show(GameState.默认界面);
            ClientCanvasCtr.instance.HideAll();
        }
        else if(!isServer && isLocalPlayer)
        {
              Debug.Log("如果是客户端那就打开客户端默认界面");
            ClientCanvasCtr.instance.Show(GameState.默认界面);
            ServerCanvasCtr.instance.HideAll();

        }
    }
    /// <summary>
    /// 初始化训练演习单向链表
    /// </summary>
    private void IniXunLianLinkedList()
    {
        XunLiangameStates.Add(GameState.角色介绍);
        XunLiangameStates.Add(GameState.训练演习选人);
        XunLiangameStates.Add(GameState.训练前情提要);
        XunLiangameStates.Add(GameState.训练演习组长预先报警);
        XunLiangameStates.Add(GameState.训练演习显示组长广播内容);
        XunLiangameStates.Add(GameState.训练演习副组长通知各人员就位);
        XunLiangameStates.Add(GameState.训练演习各人员就位);
        XunLiangameStates.Add(GameState.训练疏散引导员通知);
        XunLiangameStates.Add(GameState.训练居民引导员游戏);
        XunLiangameStates.Add(GameState.训练空袭警报);
        XunLiangameStates.Add(GameState.训练进入人防游戏);
        XunLiangameStates.Add(GameState.训练解除警报);
        XunLiangameStates.Add(GameState.训练消除空袭后果);
        XunLiangameStates.Add(GameState.训练总结);

        for (int i = 0; i < GameManager.MAX_XUN_LIAN_STATE; i++)
        {
            linkedListYanXiStates.Add(new LinkedListYanXiState());
        }
        //设置单向链表
        for (int i = 0; i < GameManager.MAX_XUN_LIAN_STATE; i++)
        {
            int nextIndex = i + 1;
            if(nextIndex < GameManager.MAX_XUN_LIAN_STATE)
            {
                linkedListYanXiStates[i].next = linkedListYanXiStates[nextIndex];

            }
            else
            {
                linkedListYanXiStates[i].next = null;
            }

            linkedListYanXiStates[i].M_GameState = XunLiangameStates[i];
        }


    }

    //修改服务器状态值
    //并且通过RPC去修改客户端值
    //服务器内客户端UI层并未更新
    [Server]
    public void ServerSetState(GameState _gameStates)
    {

        if (_gameStates == GameState.问答)
        {//问答
            Debug.Log("Server 跳转问答");
        }

        //        GameManager.instance.SetAllCharacterStateVal(_gameStates);

        if (_gameStates==GameState.角色介绍)
        {
            //开始倒计时
            if (!Istick)
            {
                Istick = true;//确保不会死循环
                linkedListYanXiStates[0].ServerSetState();
            }
            else
            {
                return;
            }
        }

        GameManager.instance.SetAllCharacterStateVal(_gameStates);

        ServerCanvasCtr.instance.Show(_gameStates);

        RpcServerSetState(_gameStates);

        Debug.Log(_gameStates + "服务端状态改变");

    }

    //有Player3服务器玩家给来更新客户端给所有客户端广播更新
    [ClientRpc]
    public void RpcServerSetState(GameState _state)
    {
        Debug.Log(this.name+"RPC给所有");

        string LocalPlayerName = GameManager.GetCurrentLocalPlayer().name;

        //确保只有客户端被更新
        if (LocalPlayerName != "Player3")
        {
            GameState STATE = GameManager.instance.getCharacterByName(LocalPlayerName).gameState;

            ClientCanvasCtr.instance.Show(STATE);
        }


    }
    [ClientRpc]
    public void RpcResetLocalPlayerQAbtn()
    {
        //由player3 服务器在客户端上的玩家来给客户端同步UI;
            ClientCanvasCtr.instance.RestQAbtn();

    }

    /// <summary>
    /// 选择后更新服务器上玩家头像
    /// </summary>
    /// <param name="readerBytes"></param>
    /// <param name="playerName"></param>
    [Command(channel = 0)]
    public void CmdUpdateCharacterPhoto(byte[] readerBytes,string playerName)
    {
        //改变Command的YANXUN状态
        Debug.Log("服务器接收BYTES并转换成TEXTURE2D");
        Texture2D texture2D = M_Utility.GetTexture2d(readerBytes);

        GameManager.GetPlayer(playerName).PlayerPhoto = M_Utility.Texture2DtoSprite(texture2D);

        RpcSetClientIDPhot(readerBytes, playerName);
    }
    /// <summary>
    /// 选择后服务器完成检查后同步给客户端玩家头像图片
    /// </summary>
    /// <param name="readerBytes"></param>
    /// <param name="playerName"></param>
    [ClientRpc]
    public void RpcSetClientIDPhot(byte[] readerBytes, string playerName)
    {
        Debug.Log("给所有Client同步图片");
        Texture2D texture2D = M_Utility.GetTexture2d(readerBytes);

        GameManager.GetPlayer(playerName).PlayerPhoto = M_Utility.Texture2DtoSprite(texture2D);
        //不用修改状态RPC给所有CLIENT 否则就是当一个人拍照连入后所有人一起进入下一个状态
        //GameManager.instance.YanYunState = YanYun.PlayerSelectCharacterState;
    }

    //选定角色
    /// <summary>
    /// 被BtnLockedDownPeople方法调用，客户端通知服务器我选中了某个角色
    /// </summary>
    /// <param name="id">选中角色ID</param>
    /// <param name="_PlayerName">玩家名字</param>
    [Command]
    public void CmdTryLockDownPeople(int id, string _PlayerName)
    {
        ServerPeopleSelectionGui serverPeopleSelectionGui = ServerCanvasCtr.instance.serverPeopleSelectionGui;
        Debug.Log(serverPeopleSelectionGui.IsServerBtnLocked(id));

        if (serverPeopleSelectionGui.IsServerBtnLocked(id))
        {
            Debug.Log("服务器上选人已被锁");
            return;
        }
        //锁定服务器人物
        serverPeopleSelectionGui.LockCharacterGui(id);
        //更新人物照片
        Sprite s =GameManager.GetPlayer(_PlayerName).PlayerPhoto;
        serverPeopleSelectionGui.SetPlayerPhoto(id, s);

        //在服务端更新数据
        UpdateCharacterData( id, _PlayerName);

        RpcTryLockDownPeople( id,  _PlayerName);
    }

    private void UpdateCharacterData(int id, string _PlayerName) {
        GameManager.instance.SetCharacterLockedVal(_PlayerName, true);
        GameManager.instance.SetCharacterSelectIDVal(_PlayerName, id);
     }
    /// <summary>
    /// 选定角色后经服务器确认RPC给所有Client
    /// </summary>
    /// <param name="id"></param>
    /// <param name="_PlayerName"></param>
    [ClientRpc]
    public void RpcTryLockDownPeople(int id, string _PlayerName) {
        ClientPeopleSelectionGui clientPeopleSelectionGui = ClientCanvasCtr.instance.clientPeopleSelectionGui;

        Debug.Log("RPC CLIENT" + id);
        //更新人物照片
        Sprite s = GameManager.GetPlayer(_PlayerName).PlayerPhoto;
        clientPeopleSelectionGui.clientSelect.SetPlayerPhoto(id, s);

        //锁定服务器人物
        clientPeopleSelectionGui.clientSelect.LockCharacterGui(id);

    }


    [Command]
    public void CmdServerPlayerResetChange()
    {
        ServerPeopleSelectionGui.instance.ResetMe();
        RpcClientCanvasReset();
    }

    [ClientRpc]
    public void RpcClientCanvasReset()
    {
        ClientCanvasCtr.instance.ResetClientCanvas();
    }

}
[System.Serializable]
public class LinkedListYanXiState
{
    public LinkedListYanXiState next;
    public GameState M_GameState;

    public LinkedListYanXiState(GameState _MyGameState, LinkedListYanXiState _next)
    {
        M_GameState = _MyGameState;
        next = _next;
    }

    public LinkedListYanXiState()
    {

    }

    public void ServerSetState()
    {



        if (next == null)
        {
            if (M_GameState != GameState.角色介绍)
            {
                GameManager.instance.tick.UnRegisterfinishCountDownEvent(ServerSetState);
            }
            GameManager.GetServerPlayer().ServerSetState(M_GameState);

            return;
        }
        else
        {
            if (M_GameState != GameState.角色介绍)
            {
                GameManager.instance.tick.UnRegisterfinishCountDownEvent(ServerSetState);
            }

            GameManager.GetServerPlayer().ServerSetState(M_GameState);

            GameManager.instance.tick.RegisterfinishCountDownEventr(next.ServerSetState);
        }
    }
}
