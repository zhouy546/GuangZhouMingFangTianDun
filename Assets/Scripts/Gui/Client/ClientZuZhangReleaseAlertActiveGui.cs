using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientZuZhangReleaseAlertActiveGui : I_Image
{
    public I_Text debugText;
    // Start is called before the first frame update

    public GameObject subGraph;
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
        subGraph.GetComponent<Image>().raycastTarget = false;
        subGraph.GetComponent<Image>().enabled=false;
    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        subGraph.GetComponent<Image>().raycastTarget = true;

        subGraph.GetComponent<Image>().enabled = true;

    }


}
