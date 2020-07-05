using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera sceneCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)//关闭非LOCALPLAYER的摄像机和控制
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);

        Debug.Log("ClientStart");


    }

    public override void OnNetworkDestroy()
    {

        Debug.Log("NetworkDestory");

        base.OnNetworkDestroy();
    }

    public override void OnStopAuthority()
    {
        base.OnStopAuthority();
        Debug.Log("OnStopAuthority");

    }


    public void OnConnectedToServer()
    {
        Debug.Log("我连接到了服务器");
    }

    //public void OnPlayerConnected(NetworkIdentity player)
    //{
    //    Debug.Log("玩家链接");
    //}


    private void OnDisable()
    {

        GameManager.UnRegisterPlayer(transform.name);

       GameManager.instance.RemoveCharacterByName(this.name);
    }
}
