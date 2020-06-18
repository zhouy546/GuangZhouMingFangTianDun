using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHouQingBaseGameActive : I_Image
{
    public I_Text debugText;

    public GameObject[] gameobjectGraphs;
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

        foreach (var item in gameobjectGraphs)
        {
            item.SetActive(false);
        }
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        gameobjectGraphs[0].SetActive(true);
    }

    public void ShowStage2()
    {
        gameobjectGraphs[0].SetActive(false);

        gameobjectGraphs[1].SetActive(true);

    }
}
