using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientYinDaoYuanBaseGameActive : I_Image
{
//public I_Text debugText;

    public GameObject[] SubgameObjects = new GameObject[2];
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
        //debugText.Hide();

        foreach (var item in SubgameObjects)
        {
            item.SetActive(false);
        }
    }

    public override void Show()
    {
        base.Show();
     //  debugText.Show();
        foreach (var item in SubgameObjects)
        {
            item.SetActive(true);
        }
    }
}
