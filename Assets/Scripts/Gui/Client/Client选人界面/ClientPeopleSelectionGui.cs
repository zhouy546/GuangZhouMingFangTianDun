using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientPeopleSelectionGui : I_Image
{
    public I_Image TakePhotoGui;
    public I_Image ClientSelectGui;
    public I_Text debugText;
    public ClientSelect clientSelect;

    public I_Image Next;
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
        TakePhotoGui.Hide();
        debugText.Hide();
        ClientSelectGui.Hide();
    }

    public override void Show()
    {
        base.Show();
        TakePhotoGui.Show();
        debugText.Show();
    }

    public void HideAll()
    {

    }
}
