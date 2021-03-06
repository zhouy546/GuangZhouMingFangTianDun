﻿using System.Collections;
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


    public ClientQA clientQA;


    public GameObject ClientBg;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        //这个是有两种情况的
        XunLiangameStates.Add(GameState.训练演习组长预先报警);
       // XunLiangameStates.Add(GameState.训练演习显示组长广播内容);



        GameState_ClientGui_kP.Add(GameState.默认界面, ClintGui[0]);
        GameState_ClientGui_kP.Add(GameState.角色介绍, ClintGui[1]);
        GameState_ClientGui_kP.Add(GameState.训练演习选人, ClintGui[2]);
        GameState_ClientGui_kP.Add(GameState.训练前情提要, ClintGui[3]);
        GameState_ClientGui_kP.Add(GameState.训练演习组长预先报警, ClintGui[4]);
        GameState_ClientGui_kP.Add(GameState.训练演习显示组长广播内容, ClintGui[5]);
        GameState_ClientGui_kP.Add(GameState.训练演习副组长通知各人员就位, ClintGui[6]);
        GameState_ClientGui_kP.Add(GameState.训练演习各人员就位, ClintGui[7]);
        GameState_ClientGui_kP.Add(GameState.训练疏散引导员通知, ClintGui[8]);
        GameState_ClientGui_kP.Add(GameState.训练居民引导员游戏, ClintGui[9]);
        GameState_ClientGui_kP.Add(GameState.训练空袭警报, ClintGui[10]);
        GameState_ClientGui_kP.Add(GameState.训练进入人防游戏, ClintGui[11]);
        GameState_ClientGui_kP.Add(GameState.训练解除警报, ClintGui[12]);
        GameState_ClientGui_kP.Add(GameState.训练消除空袭后果, ClintGui[13]);
        GameState_ClientGui_kP.Add(GameState.训练总结, ClintGui[14]);

        GameState_ClientGui_kP.Add(GameState.问答, ClintGui[15]);


        HideAll();

        StartCoroutine(SetClientBG());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SetClientBG()
    {
        yield return new WaitForSeconds(2);

        Debug.Log(GameManager.M_isServer);
        if (GameManager.M_isServer)
        {
            ClientBg.SetActive(false);
        }
        else
        {
            ClientBg.SetActive(true);

        }
    } 

    public void HideAll()
    {
        foreach (var item in GameState_ClientGui_kP)
        {

            GameState_ClientGui_kP[item.Key].Hide();

        }
    }


    public void RestQAbtn() {
        clientQA.resetbtn();
    }

    public void ResetClientCanvas() {
        ClientPeopleSelectionGui.instance.ResetAll();
    }


    public void UpdateMyEvluation()
    {
        List<bool> RightNum = new List<bool>();

        string evlString = "";

        Debug.Log(GameManager.GetCurrentLocalPlayer().name);

        //获取本地玩家游戏评价
        string localPlayerNamer = GameManager.GetCurrentLocalPlayer().name;

        GameManager.characters character = GameManager.instance.getCharacterByName(localPlayerNamer);

        professionalInfo ProfessionalInfo = GameManager.kp_LockedID_ProfessionalInfo[character.SelectID];

        List<I_Image> ClientActiveStates = new List<I_Image>();
        ClientActiveStates = ProfessionalInfo.ClientActiveState;


        Debug.Log("需要检查的阶段数量：" + ClientActiveStates.Count);
        foreach (var item in ClientActiveStates)
        {
            string[] temp = item.GetEvluationString();

            Debug.Log(temp[1]);

            RightNum.Add(ConverStringTureFalse(temp[0]));

            evlString = evlString + temp[1] + "\n";//可能存在问题
        }

        Debug.Log(evlString);

        int star = getStart(1, 3, RightNum);




        Debug.Log("本地玩家姓名" + localPlayerNamer);

        Player player = GameManager.GetCurrentLocalPlayer();

        player.CmdSetPlayerStar_Evluation(player.name, evlString, star);


        //  CmdSetPlayerStar_Evluation("Player4", "测试", star);

        evlString = "";
    }



    bool ConverStringTureFalse(string s)
    {

        if (s == "True")
        {
            return true;
        }
        else if (s == "False")
        {
            return false;
        }
        else
        {
            return false;
        }

    }

    public int getStart(int outmin, int outmax, List<bool> b)
    {
        int rightDoing = 0;

        foreach (var item in b)
        {
            if (item)
            {
                rightDoing++;
            }
        }

        return Mathf.FloorToInt(M_Utility.Maping(rightDoing, 0, b.Count, outmin, outmax, true));


    }

    public void Show(GameState _gameState)
    {

        if (_gameState == GameState.训练总结)
        {
            UpdateMyEvluation();
        }
        //if (XunLiangameStates.Contains(_gameState))
        //{
        //    foreach (var item in GameState_ClientGui_kP)
        //    {
        //        if (item.Key == _gameState)
        //        {
        //            //获取当前玩家是否选择了此状态
        //            Player Tplayer = GameManager.GetCurrentLocalPlayer();

        //            //获取当前玩家CHARACTER信息
        //            GameManager.characters Tcharacters = GameManager.instance.getCharacterByName(Tplayer.name);

        //            //Client选中的需要被激活的状态
        //            GameState ClientSelectGameState = GameManager.SelectID_ActiveState_KP[Tcharacters.SelectID];

        //            if(ClientSelectGameState== _gameState)
        //            {
        //                GameState_ClientGui_kP[_gameState].ShowDisableOrActiveOne(true);

        //            }
        //            else
        //            {
        //                GameState_ClientGui_kP[_gameState].ShowDisableOrActiveOne(false);

        //            }

        //        }
        //    }
        //}
      //  else
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
