using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientAllCharacterStandby : I_Image
{
     public I_Text debugText;
    // Start is called before the first frame update

    public List<int> ActiveIndex = new List<int>();

    public ClientAllCharacterStandbyActive clientAllCharacterStandbyActive;
    public ClientAllCharacterStandbyDisable clientAllCharacterStandbyDisable;
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
        clientAllCharacterStandbyActive.Hide();
        clientAllCharacterStandbyDisable.Hide();
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        debugText.Show();
        ShowDisableOrActiveOne();
    }

    public override void ShowDisableOrActiveOne()
    {
        if (IsShowFuZuZhangAlertGui())
        {
            clientAllCharacterStandbyActive.Show();
            clientAllCharacterStandbyDisable.Hide();
        }
        else
        {
            clientAllCharacterStandbyActive.Hide();
            clientAllCharacterStandbyDisable.Show();
        }
    }

    bool IsShowFuZuZhangAlertGui()
    {
        int LockDonwIndex = GameManager.instance.getCharacterByName(GameManager.GetCurrentLocalPlayer().name).SelectID;
        return ActiveIndex.Contains(LockDonwIndex);

    }
}
