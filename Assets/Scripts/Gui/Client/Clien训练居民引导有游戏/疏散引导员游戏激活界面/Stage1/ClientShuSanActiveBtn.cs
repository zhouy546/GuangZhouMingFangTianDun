using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientShuSanActiveBtn : MonoBehaviour
{
    public GameObject[] OnClickGraph;

    public bool isRightAnswer;

    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getIsRightAnswer()
    {
        if (isSelected == isRightAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ShowRightAnswer()
    {
        if (isRightAnswer)
        {
            this.GetComponent<Image>().color = Color.green;
        }
    }


    public void OnClick() {
        if (isSelected) {
            foreach (var item in OnClickGraph)
            {
                item.SetActive(false);
            }
            isSelected = false;
        }
        else
        {
            foreach (var item in OnClickGraph)
            {
                item.SetActive(true);
            }

            isSelected = true;
        }


    }

    public void OnEnable()
    {
        foreach (var item in OnClickGraph)
        {
            item.SetActive(false);
        }
        this.GetComponent<Image>().color = Color.white;
    }




}
