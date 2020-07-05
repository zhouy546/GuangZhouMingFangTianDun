using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetWorkingCtr : NetworkManager
{
    public NetworkManager networkManager;
    public GameObject ReConnectUi;
    public bool M_ISERVER = true;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.INI, ini);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(networkManager.);
    }

    public void ini() {

        //var config = new ConnectionConfig();
        //config.AddChannel(QosType.ReliableSequenced);
        //config.AddChannel(QosType.Unreliable);
        //NetworkServer.Configure(config, 20);


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


    public override void OnClientError(NetworkConnection conn, int errorCode)
    {
        base.OnClientError(conn, errorCode);

        Debug.Log("Error");
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        Debug.Log("DisConnected");


        if (GameManager.M_isServer == false)
        {
            ReConnectUi.SetActive(true);
        }

    }

    public void reconnect() {
        if (GameManager.M_isServer)
        {

            networkManager.StartHost();
        }
        else
        {
            networkManager.networkAddress = GameManager.ServerIp;
            networkManager.StartClient();

            ReConnectUi.SetActive(false);

        }


    }

}
