using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZhiYuanZheBaseGameActive : I_Image
{
    public I_Text debugText;

    public GameObject[] stages;

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

    IEnumerator CountDown()
    {
        currentCountDown--;
        yield return new WaitForSeconds(1);

        if (currentCountDown == 0)
        {
            GotoStage1();
            StopAllCoroutines();
            currentCountDown = DefaultCountDown;

        }

        StartCoroutine(CountDown());


    }


    public override void Hide()
    {
        base.Hide();
        debugText.Hide();

        stages[0].SetActive(false);
        stages[1].SetActive(false);
        stages[1].SetActive(false);
        StopAllCoroutines();
        currentCountDown = DefaultCountDown;
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();

        stages[0].SetActive(false);
        stages[1].SetActive(false);
        stages[2].SetActive(true);
        StartCoroutine(CountDown());
    }

    public void GotoStage1()
    {
        stages[0].SetActive(true);
        stages[1].SetActive(false);
        stages[2].SetActive(false);
    }

    public void GoToStage2() {
        stages[0].SetActive(false);
        stages[1].SetActive(true);
        stages[2].SetActive(false);

    }
}
