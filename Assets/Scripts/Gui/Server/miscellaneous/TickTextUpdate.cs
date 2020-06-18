using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickTextUpdate : MonoBehaviour
{
    public Text text;
    public Tick tick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = tick.CurrentCountDonwTime.ToString();
    }
}
