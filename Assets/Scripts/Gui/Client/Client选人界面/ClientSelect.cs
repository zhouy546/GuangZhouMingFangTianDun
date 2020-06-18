using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientSelect : I_Image
{
    public GameObject SubUI;

    public int LockDownID = -1;

    public List<Button> CharacterBtns = new List<Button>();

    public Sprite defaultBtnSprite;
    public Sprite WaitingBtnSprite;

    public Button SelectionBtn;
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
        SubUI.SetActive(false);



    }

    public override void Show()
    {
        base.Show();
        SubUI.SetActive(true);
        SelectionBtn.GetComponent<Image>().sprite = defaultBtnSprite;


    }

    public void PeopleLockedDown()
    {

    }

    /// <summary>
    /// 关闭按钮，角色已被人锁定
    /// </summary>
    /// <param name="num"></param>
    public void DisableBtn(int num)
    {
        CharacterBtns[num].Select();
        CharacterBtns[num].interactable = false;
    }

    /// <summary>
    /// 用户界面手点击选着角色后高亮并且更新当前ID
    /// </summary>
    /// <param name="ID">选中的角色ID</param>
    public void OnSelectID(int ID)
    {
        LockDownID = ID;
    }

    /// <summary>
    /// 选中后确定按钮，将选中消息发送给服务器确认
    /// </summary>
    public void BtnLockedDownPeople()
    {
        Player player = GameManager.GetCurrentLocalPlayer();
        bool _isLocked = GameManager.instance.getCharacterByName(player.name).isLocked;
        if (LockDownID == -1 || _isLocked)
        {
            return;
        }



        Debug.Log("客户端按钮ID" + LockDownID);
        player.CmdTryLockDownPeople(LockDownID, player.name);

        SelectionBtn.GetComponent<Image>().sprite = WaitingBtnSprite;
    }

    public void LockCharacterGui(int id)
    {
        CharacterBtns[id].interactable = false;
    }

    //即将替换成Btn下的MASK下的图片
    public void SetPlayerPhoto(int id, Sprite sprite)
    {
        CharacterBtns[id].GetComponent<ClientSelectBtn>().CharacterSprite.sprite = sprite;
    }
}
