using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientPeopleSelectionGui : I_Image
{
    public I_Image TakePhotoGui;
    public I_Image ClientSelectGui;
    public ClientSelect clientSelect;

    public I_Image Next;

    public Sprite DefaultCharacterSprite;
    public List<Image> PlayerPhoto = new List<Image>();
    public List<Button> SelectButtons = new List<Button>();

    public static ClientPeopleSelectionGui instance;

    public override void Awake()
    {
        base.Awake();

        instance = this;

    }

    public void ResetAll() {
        foreach (var item in SelectButtons)
        {
            item.interactable = true;

            int i = SelectButtons.IndexOf(item);
            PlayerPhoto[i].sprite = DefaultCharacterSprite;
        }
    }

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

        ClientSelectGui.Hide();
    }

    public override void Show()
    {
        base.Show();
        TakePhotoGui.Show();

    }

    public void HideAll()
    {

    }
}
