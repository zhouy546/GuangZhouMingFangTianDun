using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientYinDaoYuanGamingActive : I_Image
{
    public I_Text debugText;
    public GameObject Stage1;
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
        Stage1.SetActive(false);

    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        Stage1.SetActive(true);
    }



}
