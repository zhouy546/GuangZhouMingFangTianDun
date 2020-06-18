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

    public Sprite defaultSprite;

    public List<Image> ServerCharacterimages = new List<Image>();

    public int TickTime;

    public static ServerPeopleSelectionGui instance;

    public override void Awake()
    {
        base.Awake();
        instance = this;
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
        SelectionGui.SetActive(false);
        debugText.Hide();
    }

    public override void Show()
    {
        base.Show();
        SelectionGui.SetActive(true);
        debugText.Show();
        SetTick();
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
        ServerCharacterimages[id].sprite = sprite;
    }

    public void ResetMe()
    {
        foreach (var item in ServerCharacterBtns)
        {

            int i = ServerCharacterBtns.IndexOf(item);

            ServerCharacterimages[i].sprite = defaultSprite;
            item.interactable = true;

            GameManager.instance.GetComponent<Tick>().Func_StopCountDonw();
        }
    }

    public override void SetTick()
    {
        if (GameManager.GetServerPlayer().isLocalPlayer)
        {
            Tick tick = GameManager.instance.GetComponent<Tick>();

            tick.DefaultCountDonwTime = TickTime;
            tick.CurrentCountDonwTime = TickTime;
        }
    }



}
