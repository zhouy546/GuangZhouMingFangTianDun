using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientRenFangGame : I_Image
{

    public List<int> YinDaoYuanID = new List<int>();
    public List<int> ZhiAnBaoZhangID = new List<int>();
    public List<int> HouQingID = new List<int>();
    public List<int> ZhiYuanZheID = new List<int>();
    public I_Text debugText;
    public ClientYinDaoYuanBaseGameActive clientYinDaoYuanBaseGameActive;
    public ClientZhiAnBaseGameActive clientZhiAnBaseGameActive;
    public ClientHouQingBaseGameActive clientHouQingBaseGameActive;
    public ClientZhiYuanZheBaseGameActive clientZhiYuanZheBaseGameActive;
    public ClientOtherBaseGameDisable clientOtherBaseGameDisable;
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
        clientYinDaoYuanBaseGameActive.Hide();
        clientZhiAnBaseGameActive.Hide();
        clientHouQingBaseGameActive.Hide();
        clientZhiYuanZheBaseGameActive.Hide();
        clientOtherBaseGameDisable.Hide();
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        ShowDisableOrActiveOne();
    }

    public override void ShowDisableOrActiveOne()
    {
        if (IsShow(YinDaoYuanID))
        {
            clientYinDaoYuanBaseGameActive.Show();
            clientZhiAnBaseGameActive.Hide();
            clientHouQingBaseGameActive.Hide();
            clientZhiYuanZheBaseGameActive.Hide();
            clientOtherBaseGameDisable.Hide();
        }
        else if (IsShow(ZhiAnBaoZhangID))
        {
            clientYinDaoYuanBaseGameActive.Hide();
            clientZhiAnBaseGameActive.Show();
            clientHouQingBaseGameActive.Hide();
            clientZhiYuanZheBaseGameActive.Hide();
            clientOtherBaseGameDisable.Hide();
        }
        else if (IsShow(HouQingID))
        {
            clientYinDaoYuanBaseGameActive.Hide();
            clientZhiAnBaseGameActive.Hide();
            clientHouQingBaseGameActive.Show();
            clientZhiYuanZheBaseGameActive.Hide();
            clientOtherBaseGameDisable.Hide();
        }
        else if (IsShow(ZhiYuanZheID))
        {
            clientYinDaoYuanBaseGameActive.Hide();
            clientZhiAnBaseGameActive.Hide();
            clientHouQingBaseGameActive.Hide();
            clientZhiYuanZheBaseGameActive.Show();
            clientOtherBaseGameDisable.Hide();
        }
        else
        {
            clientYinDaoYuanBaseGameActive.Hide();
            clientZhiAnBaseGameActive.Hide();
            clientHouQingBaseGameActive.Hide();
            clientZhiYuanZheBaseGameActive.Hide();
            clientOtherBaseGameDisable.Show();
        }
    }

    bool IsShow(List<int> _ActiveIndex)
    {
        int LockDonwIndex = GameManager.instance.getCharacterByName(GameManager.GetCurrentLocalPlayer().name).SelectID;
        return _ActiveIndex.Contains(LockDonwIndex);

    }
}
