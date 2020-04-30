using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientCanvasCtr : MonoBehaviour
{
    public static ClientCanvasCtr instance;
    public List<I_Image> ClintGui = new List<I_Image>();
    public ClientPeopleSelectionGui clientPeopleSelectionGui;

    public Dictionary<GameState, I_Image> GameState_ClientGui_kP = new Dictionary<GameState, I_Image>();
    // Start is called before the first frame update
    List<GameState> XunLiangameStates = new List<GameState>();

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        XunLiangameStates.Add(GameState.训练演习组长警示);
        XunLiangameStates.Add(GameState.副组长通知各人员就位);



        GameState_ClientGui_kP.Add(GameState.默认界面, ClintGui[0]);
        GameState_ClientGui_kP.Add(GameState.训练演习选人, ClintGui[1]);
        GameState_ClientGui_kP.Add(GameState.训练演习组长警示, ClintGui[2]);
     //   GameState_ClientGui_kP.Add(GameState.副组长通知各人员就位, ClintGui[3]);

        HideAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAll()
    {
        foreach (var item in GameState_ClientGui_kP)
        {

            GameState_ClientGui_kP[item.Key].Hide();

        }
    }

    public void Show(GameState _gameState)
    {
        if (XunLiangameStates.Contains(_gameState))
        {
            foreach (var item in GameState_ClientGui_kP)
            {
                if (item.Key == _gameState)
                {
                    //获取当前玩家是否选择了此状态
                    Player Tplayer = GameManager.GetCurrentLocalPlayer();

                    //获取当前玩家CHARACTER信息
                    GameManager.characters Tcharacters = GameManager.instance.getCharacterByName(Tplayer.name);

                    //Client选中的需要被激活的状态
                    GameState ClientSelectGameState = GameManager.SelectID_ActiveState_KP[Tcharacters.SelectID];

                    if(ClientSelectGameState== _gameState)
                    {
                        GameState_ClientGui_kP[_gameState].ShowDisableOrActiveOne(true);

                    }
                    else
                    {
                        GameState_ClientGui_kP[_gameState].ShowDisableOrActiveOne(false);

                    }

                }
            }
        }
        else
        {
            foreach (var item in GameState_ClientGui_kP)
            {
                if (item.Key == _gameState)
                {
                    GameState_ClientGui_kP[_gameState].Show();
                }
                else
                {
                    GameState_ClientGui_kP[item.Key].Hide();
                }
            }
        }

    }

}
