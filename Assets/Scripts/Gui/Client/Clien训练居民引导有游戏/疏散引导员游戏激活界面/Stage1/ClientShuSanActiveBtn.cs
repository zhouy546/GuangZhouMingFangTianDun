using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientShuSanActiveBtn : MonoBehaviour
{
    public GameObject[] OnClickGraph;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        foreach (var item in OnClickGraph)
        {
            item.SetActive(true);
        }
    }

    public void OnEnable()
    {
        foreach (var item in OnClickGraph)
        {
            item.SetActive(false);
        }
    }




}
