using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientJuMingItemSubmit : MonoBehaviour
{

    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {//提交确定
        button.interactable = false;

    }

    public void OnDisable()
    {
        button.interactable = true;
    }
}
