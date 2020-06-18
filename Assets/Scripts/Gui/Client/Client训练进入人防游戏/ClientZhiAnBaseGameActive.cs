using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZhiAnBaseGameActive : I_Image
{
    public I_Text debugText;

    public GameObject[] graphs_gameObject;
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

        foreach (var item in graphs_gameObject)
        {
            item.SetActive(false);

        }
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        foreach (var item in graphs_gameObject)
        {
            item.SetActive(true);
        }
    }
}
