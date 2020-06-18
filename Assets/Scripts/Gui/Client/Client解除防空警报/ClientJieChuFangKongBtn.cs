using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientJieChuFangKongBtn : MonoBehaviour
{


    public void OnDisable()
    {
        this.GetComponent<Button>().interactable = true ;
    }

    public void OnClick() {
        this.GetComponent<Button>().interactable = false;
    }
}
