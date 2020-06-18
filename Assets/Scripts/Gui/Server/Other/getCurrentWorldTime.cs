using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getCurrentWorldTime : MonoBehaviour
{

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdateTime()
    {

       string time = GetIme();

        text.text = time;

        yield return new WaitForSeconds(10f);

        StartCoroutine(UpdateTime());
    }


    public string GetIme()
    {
   string hour =      DateTime.Now.Hour.ToString();
 string Minute =   DateTime.Now.Minute.ToString();

        return hour + " : " + Minute;
    }
}
