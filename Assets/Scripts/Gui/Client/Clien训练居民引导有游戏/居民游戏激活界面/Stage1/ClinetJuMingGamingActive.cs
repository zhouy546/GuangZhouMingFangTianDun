using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClinetJuMingGamingActive : I_Image
{
    public I_Text debugText;
    public GameObject STAGE1;
    public GameObject STAGE2;

    public List<Image> Stage1Checkimages = new List<Image>();

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
        STAGE1.SetActive(false);
        STAGE2.SetActive(false);

    }

    public override void Show()
    {
        base.Show();
        debugText.Show();
        STAGE1.SetActive(true);
        STAGE2.SetActive(false);
    }

    public void GoToStage2() {
        STAGE1.SetActive(false);
        STAGE2.SetActive(true);
    }

    public bool CheckGoNextStage()
    {
        foreach (var m_image in Stage1Checkimages)
        {
            if(m_image.enabled == true)
            {
                return false;
            }
        }

        return true;
    }
}
