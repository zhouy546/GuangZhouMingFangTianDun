using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHouQingBaseGameActive : I_Image
{
    public I_Text debugText;

    public GameObject[] gameobjectGraphs;

    public int DefaultCountDown = 116;

    public int currentCountDown = 116;
    // Start is called before the first frame update
    void Start()
    {
        currentCountDown = DefaultCountDown;
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


        StopAllCoroutines();
        currentCountDown = DefaultCountDown;
    }

    IEnumerator CountDown()
    {
        currentCountDown--;
        yield return new WaitForSeconds(1);

        if (currentCountDown == 0)
        {
            ShowStage1();

            StopAllCoroutines();
            currentCountDown = DefaultCountDown;

        }

        StartCoroutine(CountDown());


    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        gameobjectGraphs[0].SetActive(false);
        gameobjectGraphs[1].SetActive(false);
        gameobjectGraphs[2].SetActive(true);
        StartCoroutine(CountDown());
    }

    public void ShowStage1()
    {
        gameobjectGraphs[0].SetActive(true);
        gameobjectGraphs[1].SetActive(false);
        gameobjectGraphs[2].SetActive(false);

    }

    public void ShowStage2()
    {
        gameobjectGraphs[0].SetActive(false);
        gameobjectGraphs[1].SetActive(true);
        gameobjectGraphs[2].SetActive(false);

    }
}
