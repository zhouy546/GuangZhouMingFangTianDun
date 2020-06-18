using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientShuSanActiveGameSubmit : MonoBehaviour
{
    public Button button;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        button.interactable = false;
        image.raycastTarget = false;
    }

    public void OnDisable()
    {
        Debug.Log("引导员界面关闭");
        button.interactable = true;
        image.raycastTarget = true; ;
    }

    public void OnEnable()
    {
        Debug.Log("引导员界面显示");
        button.interactable = true;
        image.raycastTarget = true; ;
    }
}
