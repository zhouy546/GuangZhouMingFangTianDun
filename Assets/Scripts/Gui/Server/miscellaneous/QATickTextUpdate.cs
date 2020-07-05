using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QATickTextUpdate : MonoBehaviour
{
    public Text text;
    public static QATickTextUpdate instance;

    public float  WaitTime=10f;

    public Image[] Rings = new Image[4];

    public ServerQADotsCtr serverQADotsCtr;

    public Color showColor;
    public Color HideColor;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        text.color = HideColor;
    }

    // Update is called once per frame
    void Update()
    {
       // text.text = tick.CurrentCountDonwTime.ToString();
    }

    public void Show()
    {
        text.color = showColor;

        for (int i = 0; i < Rings.Length; i++)
        {
            Rings[i].enabled = true;
        }


        serverQADotsCtr.Show();
    }

    public void Hide() {
        text.color = HideColor;

        for (int i = 0; i < Rings.Length; i++)
        {
            Rings[i].enabled = false;
        }

        serverQADotsCtr.Hide();


    }

    public void UpDateText(string s)
    {

        text.text = s;

        UpdateRing(float.Parse(s));

        serverQADotsCtr.UpdateDots();
    }

    public void UpdateRing(float i)
    {
        float temp = i / WaitTime;
        Rings[0].fillAmount = temp;


    }
}
