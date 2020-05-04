using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZuZhangReleaseAlertDisableGui : I_Image
{
    public I_Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Awake()
    {
        base.Awake();
    }

    public override void Hide()
    {
        base.Hide();
        debugText.Hide();
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
    }
}
