using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerDefaultGui : I_Image
{
    public I_Text DeBugText;



    public override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Show()
    {
        base.Show();
        DeBugText.Show();
    }

    public override void Hide()
    {
        base.Hide();
        DeBugText.Hide();
    }

}
