using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistributeItemsBtn : MonoBehaviour
{


    public void OnDisable()
    {
        this.GetComponent<Button>().interactable = true;
    }

    public void Onclick()
    {
        this.GetComponent<Button>().interactable = false;
    }
}
