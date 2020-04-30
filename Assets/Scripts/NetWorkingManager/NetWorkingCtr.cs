using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetWorkingCtr : NetworkBehaviour
{
    public NetworkManager networkManager;

    public bool M_ISERVER;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( ini());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ini() {

        yield return new WaitForSeconds(1f);
        //if (M_ISERVER)
        //{
        //    networkManager.StartHost();
        //}
        //else
        //{
        //    networkManager.StartClient();
        //}
    }

    public override void OnStartServer()
    {
        Debug.Log("OnServerStart");

    }

}
