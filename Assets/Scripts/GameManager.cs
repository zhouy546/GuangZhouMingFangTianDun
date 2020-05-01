using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GameManager : NetworkBehaviour
{
    public static  int MAX_XUN_LIAN_STATE = 14;

    public static GameManager instance;

    private const string PLAYER_ID_PREFIX = "Player";

    public static Dictionary<int, GameState> SelectID_ActiveState_KP = new Dictionary<int, GameState>();

    public static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public class SyncCharacter : SyncListStruct<characters> { }

    public SyncCharacter syncCharacter = new SyncCharacter();

    public Tick tick;

    public struct characters
    {
        public int ZuoWei_ID;
        public int SelectID;
        public bool isLocked;
        public string PlayerName;
        public GameState gameState;
    }

    /// <summary>
    /// 初始化SYNCLIST 同步玩家信息
    /// </summary>
    /// <param name="_id">玩家选择人物ID</param>
    /// <param name="_isLocked">是否锁定角色</param>
    /// <param name="_name">玩家名字PLAYERXXX</param>
    /// <param name="_YanYun">游戏状态</param>
    public void IniCharacter(int _id, bool _isLocked, string _name, GameState _GameState)
    {

        characters cha = new characters();
        cha.SelectID = _id;
        cha.isLocked = _isLocked;
        cha.PlayerName = _name;
        cha.gameState = _GameState;
        syncCharacter.Add(cha);
    }

    public void RemoveCharacterByName(string PlayerName) {
        int index = syncCharacter.IndexOf(getCharacterByName(PlayerName));
        syncCharacter.Remove(syncCharacter[index]);
    
    }

    public void SetCharacterStateVal(string PlayerName, GameState _gameState)
    {
        int index = syncCharacter.IndexOf(getCharacterByName(PlayerName));
        characters temp = syncCharacter[index];
        temp.gameState = _gameState;
        syncCharacter[index] = temp;
    }

    public void SetAllCharacterStateVal(GameState _gameState)
    {
        Debug.Log(_gameState);
        for (int i = 0; i < syncCharacter.Count; i++)
        {
            characters temp = syncCharacter[i];
                    temp.gameState = _gameState;
            syncCharacter[i] = temp;
        }
    }

    public void SetCharacterSelectIDVal(string PlayerName, int _SelectID)
    {
        int index = syncCharacter.IndexOf(getCharacterByName(PlayerName));
        characters temp = syncCharacter[index];
        temp.SelectID = _SelectID;
        syncCharacter[index] = temp;
    }

    public void SetCharacterLockedVal(string PlayerName, bool _IsLocked)
    {
        int index = syncCharacter.IndexOf(getCharacterByName(PlayerName));
        characters temp = syncCharacter[index];
        temp.isLocked = _IsLocked;
        syncCharacter[index] = temp;
    }

    public void SetCharacterZuoWei_IDVal(string PlayerName, int _ZuoWei_ID)
    {
        int index = syncCharacter.IndexOf(getCharacterByName(PlayerName));
        characters temp = syncCharacter[index];
        temp.ZuoWei_ID = _ZuoWei_ID;
        syncCharacter[index] = temp;
    }
    /// <summary>
    /// 通过名字来获得characters Object 注意不能通过该方法来修改参数；修改参数需要通过SET方法
    /// </summary>
    /// <param name="keyName">玩家名字</param>
    /// <returns></returns>
    public characters getCharacterByName(string keyName)
    {

        characters te = new characters();
        for (int i = 0; i < syncCharacter.Count; i++)
        {
            if (syncCharacter[i].PlayerName == keyName)
            {
                return syncCharacter[i];
            }
        }

        Debug.Log("Search character fail");

        return te;
    }


    /// <summary>
    /// 通过玩家名字来获Player家组件
    /// </summary>
    /// <param name="_playerID">玩家名字</param>
    /// <returns></returns>
    public static Player GetPlayer(string _playerID)
    {
        return players[_playerID];
    }


    /// <summary>
    /// 获得本地玩家
    /// </summary>
    /// <returns></returns>
    public static Player GetCurrentLocalPlayer()
    {
        foreach (Player player in players.Values)
        {
            //           Debug.Log(player.M_isServer());

            if (player.isLocalPlayer)
            {
                return player;
            }
        }
        return null;

    }
    public void Awake()
    {
        SelectID_ActiveState_KP.Add(0, GameState.训练演习组长预先报警);
        SelectID_ActiveState_KP.Add(1, GameState.训练演习副组长通知各人员就位);
    }

    public void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    ///当玩家连接时注册玩家 
    /// </summary>
    /// <param name="_netID">服务器提供的ID</param>
    /// <param name="_player">该玩家PLAYER组件</param>
    public static void RegisterPlayer(string _netID, Player _player)
    {
        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;

    }
    /// <summary>
    /// 当玩家断开链接时注销玩家
    /// </summary>
    /// <param name="_PlayerID">玩家ID</param>
    public static void UnRegisterPlayer(string _PlayerID)
    {
        players.Remove(_PlayerID);
    }




    /// <summary>
    /// 获得服务器玩家组件
    /// </summary>
    /// <returns>玩家名字</returns>
    public static Player GetServerPlayer()
    {
        foreach (Player player in players.Values)
        {
            //           Debug.Log(player.M_isServer());

            if (player.isServer)
            {
                return player;
            }
        }
        return null;
    }

    

}

public enum GameState {默认界面,播放视频,问答,角色介绍,
    训练演习选人, 训练前情提要,训练演习组长预先报警,训练演习显示组长广播内容, 训练演习副组长通知各人员就位
    ,训练演习各人员就位,训练疏散引导员通知,训练居民引导员游戏,训练空袭警报,训练进入人防游戏,训练解除警报,训练消除空袭后果,
    训练总结,
}