using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerPeopleSelectionGui : I_Image
{
    public GameObject SelectionGui;
    public I_Text debugText;

    public List<Button> ServerCharacterBtns = new List<Button>();
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
        SelectionGui.SetActive(false);
        debugText.Hide();
    }

    public override void Show()
    {
        base.Show();
        SelectionGui.SetActive(true);
        debugText.Show();
    }

    public bool IsServerBtnLocked(int id)
    {
        return !ServerCharacterBtns[id].interactable;
    }

    public void LockCharacterGui(int id)
    {
        ServerCharacterBtns[id].interactable = false;
    }

    public void SetPlayerPhoto(int id,Sprite sprite)
    {
        ServerCharacterBtns[id].GetComponent<Image>().sprite = sprite;
    }
}
