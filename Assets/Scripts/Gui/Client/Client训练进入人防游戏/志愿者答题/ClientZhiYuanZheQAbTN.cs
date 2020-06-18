using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZhiYuanZheQAbTN : MonoBehaviour
{
    public ClientZhiYuanZheQAbTN clientZhiYuanZheQAbTN;

    public GameObject[] subGraph;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        HideSub();
    }

    public void  OnClick() {
        ShowSub();
        clientZhiYuanZheQAbTN.HideSub();
    }

    public void OnDisable()
    {
        HideSub();
    }

    public void  ShowSub()
    {
        foreach (var item in subGraph)
        {
            item.SetActive(true);
        }
    }

    public void HideSub()
    {
        foreach (var item in subGraph)
        {
            item.SetActive(false);
        }
    }


}
