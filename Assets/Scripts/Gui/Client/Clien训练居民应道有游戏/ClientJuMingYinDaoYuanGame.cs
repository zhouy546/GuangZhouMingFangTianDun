using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientJuMingYinDaoYuanGame : I_Image
{
    public ClientJuMingYinDaoYuanGameDisable clientJuMingYinDaoYuanGameDisable;
    public ClientYinDaoYuanGamingActive clientYinDaoYuanGamingActive; 
    public ClinetJuMingGamingActive clinetJuMingGamingActive;
    public I_Text debugText;
    public List<int> YinDaoYuanID = new List<int>();
    public List<int> JuMingID = new List<int>();

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
        clientYinDaoYuanGamingActive.Hide();
        clientJuMingYinDaoYuanGameDisable.Hide();
        clinetJuMingGamingActive.Hide();
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
            clientYinDaoYuanGamingActive.Show();
            clientJuMingYinDaoYuanGameDisable.Hide();
            clinetJuMingGamingActive.Hide();
        }
        else if (IsShow(JuMingID))
        {
            clientYinDaoYuanGamingActive.Hide();
            clientJuMingYinDaoYuanGameDisable.Hide();
            clinetJuMingGamingActive.Show();
        }
        else
        {
            clientYinDaoYuanGamingActive.Hide();
            clientJuMingYinDaoYuanGameDisable.Show();
            clinetJuMingGamingActive.Hide();
        }
    }


    bool IsShow(List<int> _ActiveIndex)
    {
        int LockDonwIndex = GameManager.instance.getCharacterByName(GameManager.GetCurrentLocalPlayer().name).SelectID;
        return _ActiveIndex.Contains(LockDonwIndex);

    }
}
