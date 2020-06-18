using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientZhiYuanZheQAsubmit1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDisable()
    {
        this.GetComponent<Button>().interactable = true;

    }

    public void OnClick()
    {
        this.GetComponent<Button>().interactable = false;
    }
}
