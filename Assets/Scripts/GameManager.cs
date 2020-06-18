using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GameManager : NetworkBehaviour
{
    //client----
    public static int PADID;

    public static string ServerIp;

    public static int ServerUDPPort=29010;

    public static int ServerGamePort=7777;



    //-------Server--
    public static string ProgramName;

    public static int Xpos;

    public static int Ypos;

    public static int ScreenWidth;

    public static int ScreenHeight;

    public static bool M_isServer = false;

    public static string VolumeUpUDP;

    public static string VolumeDownUDP;

    public static string StopUdp;

    public static Dictionary<string, VideoInfo> kp_udp_VideoInfo = new Dictionary<string, VideoInfo>();

    public static Dictionary<int, playerQAScore> kp_seatID_Answer = new Dictionary<int, playerQAScore>();

    public static Dictionary<int, QAinfo> kp_id_qAinfos = new Dictionary<int, QAinfo>();

    public static  int MAX_XUN_LIAN_STATE = 13;

    public static GameManager instance;

    private const string PLAYER_ID_PREFIX = "Player";

 //   public static Dictionary<int, GameState> SelectID_ActiveState_KP = new Dictionary<int, GameState>();

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
        for (int i = 0; i < 50; i++)
        {

            playerQAScore tempQAscore = new playerQAScore(0, "F");

            kp_seatID_Answer.Add(i, tempQAscore);
        }
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


public class VideoInfo
{
    public string url;
    public string udp;
    public bool isLoop;
    public bool isBackToScreenProtect;
    public bool isScreenProtect;

    public VideoInfo()
    {

    }

    public VideoInfo(string _url, string _udp,bool _isLoop,bool _isBackToScreenProtect,bool _isScreenProtect)
    {
      url=_url;
      udp=_udp;
      isLoop=_isLoop;
      isBackToScreenProtect = _isBackToScreenProtect;
      isScreenProtect=_isScreenProtect;
    }
}

public class QAinfo {
    public int num;
    public string question;
    public string[] A1;
    public int RightAnswer;

    public QAinfo() {

    }

    public QAinfo( int _num, string _question, string[] _A1, int _RightAnswer) {
        num = _num;
        question = _question;
        A1 = _A1;
        RightAnswer = _RightAnswer;
    }
}

public class playerQAScore
{
    public int currentScore;
    public string currentSelectAnswer;

    public playerQAScore()
    {

    }

    public playerQAScore( int _currentScore, string _currentSelectAnswer) {
        currentScore = _currentScore;
        currentSelectAnswer = _currentSelectAnswer;
    }

    public void reset()
    {
        currentScore = 0;
        currentSelectAnswer = "F";
    }

    public void GainScore()
    {
        currentScore++;
    }

    public void setCurrentAnswer(string s)
    {
        currentSelectAnswer = s;
    }
}


public enum GameState {默认界面,播放视频,问答,角色介绍,
    训练演习选人, 训练前情提要,训练演习组长预先报警,训练演习显示组长广播内容, 训练演习副组长通知各人员就位
    ,训练演习各人员就位,训练疏散引导员通知,训练居民引导员游戏,训练空袭警报,训练进入人防游戏,训练解除警报,训练消除空袭后果,
    训练总结,
}