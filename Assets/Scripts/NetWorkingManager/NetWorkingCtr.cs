using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetWorkingCtr : NetworkBehaviour
{
    public NetworkManager networkManager;

    public bool M_ISERVER = true;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.INI, ini);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ini() {

        if (GameManager.M_isServer)
        {

            networkManager.StartHost();
        }
        else
        {
            networkManager.networkAddress = GameManager.ServerIp;
            networkManager.StartClient();
        }
    }

    public override void OnStartServer()
    {
        Debug.Log("OnServerStart");

    }

}
