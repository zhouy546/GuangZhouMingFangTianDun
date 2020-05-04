using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientShuShanYinDaoYuanTongZhi : I_Image
{
    public I_Text debugText;
    // Start is called before the first frame update

    public List<int> ActiveIndex = new List<int>();

    public ClientShuShanYinDaoYuanTongZhiActive clientShuShanYinDaoYuanTongZhiActive;
    public ClientShuShanYinDaoYuanTongZhiDisable clientShuShanYinDaoYuanTongZhiDisable;
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
        clientShuShanYinDaoYuanTongZhiDisable.Hide();
        clientShuShanYinDaoYuanTongZhiActive.Hide();
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        ShowDisableOrActiveOne();
    }

    public override void ShowDisableOrActiveOne()
    {
        if (IsShowCurrentGui())
        {
            clientShuShanYinDaoYuanTongZhiActive.Show();
            clientShuShanYinDaoYuanTongZhiDisable.Hide();
        }
        else
        {
            clientShuShanYinDaoYuanTongZhiActive.Hide();
            clientShuShanYinDaoYuanTongZhiDisable.Show();
        }
    }

    bool IsShowCurrentGui()
    {
        int LockDonwIndex = GameManager.instance.getCharacterByName(GameManager.GetCurrentLocalPlayer().name).SelectID;
        return ActiveIndex.Contains(LockDonwIndex);

    }
}
