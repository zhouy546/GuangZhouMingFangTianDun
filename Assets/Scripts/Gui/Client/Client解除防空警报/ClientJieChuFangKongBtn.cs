using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientJieChuFangKongBtn : MonoBehaviour
{
    public string[] EvluationString;

    public string CurrentEvluationString;

    public bool isPassed;

    public void OnDisable()
    {
        this.GetComponent<Button>().interactable = true ;
    }

    public void OnClick() {
        this.GetComponent<Button>().interactable = false;

        PassedTest();

    }

    public string[] getvluationString()
    {
        string[] tempString = new string[2];
        if (isPassed)
        {
            tempString[0] = isPassed.ToString();
            tempString[1] = CurrentEvluationString;

            return tempString;
        }
        else
        {
            NotPassedTest();

            tempString[0] = isPassed.ToString();
            tempString[1] = CurrentEvluationString;

            return tempString;
        }
    }

    public void PassedTest()
    {
        isPassed = true;
        CurrentEvluationString = EvluationString[0];
    }

    public void NotPassedTest()
    {
        isPassed = false;
        CurrentEvluationString = EvluationString[1];
    }

    public void ResetEvluation()
    {
        isPassed = false;
        CurrentEvluationString = "";
    }
}
