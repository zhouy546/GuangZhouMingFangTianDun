﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZuZhangAlertGui : I_Image
{
    public I_Text DebugText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Hide()
    {
        base.Hide();
        DebugText.Hide();
    }

    public override void Show()
    {
        base.Show();
        DebugText.Show();
    }

    public override void Awake()
    {
        base.Awake();
    }
}
