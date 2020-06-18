using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientAllCharacterStandbyActive : I_Image
{
    public I_Text DebugText;


    public I_Image YDYBtn;

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
        YDYBtn.Hide();
    }

    public override void Show()
    {
        base.Show();
        DebugText.Show();
        YDYBtn.Show();
    }

    public override void Awake()
    {
        base.Awake();
    }
}
