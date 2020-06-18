using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerShuShanYinDaoYuanTongZhi : I_Image
{
    public I_Text debugText;

    public int TickTime;
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
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();

        SetTick();
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
