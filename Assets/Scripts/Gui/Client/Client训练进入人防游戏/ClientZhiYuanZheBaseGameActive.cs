using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZhiYuanZheBaseGameActive : I_Image
{
    public I_Text debugText;

    public GameObject[] stages;
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

        stages[0].SetActive(false);
        stages[1].SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();

        stages[0].SetActive(true);
        stages[1].SetActive(false);
    }

    public void GoToStage2() {
        stages[0].SetActive(false);
        stages[1].SetActive(true);

    }
}
