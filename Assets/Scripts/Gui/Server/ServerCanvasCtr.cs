using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerCanvasCtr : MonoBehaviour
{
    public static ServerCanvasCtr instance;

    public ServerPeopleSelectionGui serverPeopleSelectionGui;

    public List<I_Image> ServerGui = new List<I_Image>();

    public Dictionary<GameState, I_Image> GameState_ServerGui_kP = new Dictionary<GameState, I_Image>();
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        //Debug.Log("\\0");

        GameState_ServerGui_kP.Add(GameState.默认界面, ServerGui[0]);
        GameState_ServerGui_kP.Add(GameState.角色介绍, ServerGui[1]);
        GameState_ServerGui_kP.Add(GameState.训练演习选人, ServerGui[2]);
        GameState_ServerGui_kP.Add(GameState.训练前情提要, ServerGui[3]);
        GameState_ServerGui_kP.Add(GameState.训练演习组长预先报警, ServerGui[4]);
        GameState_ServerGui_kP.Add(GameState.训练演习显示组长广播内容, ServerGui[5]);
        GameState_ServerGui_kP.Add(GameState.训练演习副组长通知各人员就位, ServerGui[6]);
        GameState_ServerGui_kP.Add(GameState.训练演习各人员就位, ServerGui[7]);
        GameState_ServerGui_kP.Add(GameState.训练疏散引导员通知, ServerGui[8]);
        GameState_ServerGui_kP.Add(GameState.训练居民引导员游戏, ServerGui[9]);
        GameState_ServerGui_kP.Add(GameState.训练空袭警报, ServerGui[10]);
        GameState_ServerGui_kP.Add(GameState.训练进入人防游戏, ServerGui[11]);
        GameState_ServerGui_kP.Add(GameState.训练解除警报, ServerGui[12]);
        GameState_ServerGui_kP.Add(GameState.训练消除空袭后果, ServerGui[13]);
        GameState_ServerGui_kP.Add(GameState.训练总结, ServerGui[14]);
        GameState_ServerGui_kP.Add(GameState.问答, ServerGui[15]);
        HideAll();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideAll()
    {
        foreach (var item in GameState_ServerGui_kP)
        {

                GameState_ServerGui_kP[item.Key].Hide();

        }
    }

    public void Show(GameState _gameState)
    {
        foreach (var item in GameState_ServerGui_kP)
        {
            if (item.Key == _gameState)
            {
                GameState_ServerGui_kP[_gameState].Show();
            }
            else
            {
                GameState_ServerGui_kP[item.Key].Hide();
            }
        }
    }


}
