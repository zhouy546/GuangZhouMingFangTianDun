using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZhiAnBaseGameActive : I_Image
{
    public I_Text debugText;

    public GameObject[] graphs_gameObject;

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

    void GotoStage1() {
        graphs_gameObject[0].SetActive(true);
        graphs_gameObject[1].SetActive(false);
    }

    public override void Hide()
    {
        base.Hide();
        debugText.Hide();

        foreach (var item in graphs_gameObject)
        {
            item.SetActive(false);
        }

        StopAllCoroutines();
        currentCountDown = DefaultCountDown;
    }

    public override void Show()
    {
        base.Show();
        //debugText.Show();
        graphs_gameObject[0].SetActive(false);
        graphs_gameObject[1].SetActive(true);

        StartCoroutine(CountDown());
    }
}
