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

        GameState_ServerGui_kP.Add(GameState.默认界面, ServerGui[0]);
        GameState_ServerGui_kP.Add(GameState.训练演习选人, ServerGui[1]);
        GameState_ServerGui_kP.Add(GameState.训练演习组长警示, ServerGui[2]);
        GameState_ServerGui_kP.Add(GameState.副组长通知各人员就位, ServerGui[3]);

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
