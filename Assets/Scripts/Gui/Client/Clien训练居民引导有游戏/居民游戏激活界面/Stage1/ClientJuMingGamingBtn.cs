using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientJuMingGamingBtn : MonoBehaviour
{

    public Button button;
    public Image textImage;


    public Sprite DefaultSprite;
    public Sprite closeSprite;

    public Sprite defaultTextSprite;

    public ClinetJuMingGamingActive clinetJuMingGamingActive;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        button.GetComponent<Image>().sprite = closeSprite;
        button.GetComponent<Image>().raycastTarget = false;
        textImage.enabled = false;
        button.interactable = false;

        if (clinetJuMingGamingActive.CheckGoNextStage())
        {
            clinetJuMingGamingActive.GoToStage2();
        }
    }


    public void OnEnable()
    {
        button.GetComponent<Image>().raycastTarget = true;
        button.interactable = true;
        button.GetComponent<Image>().sprite = DefaultSprite;
        textImage.enabled = true;
        textImage.sprite = defaultTextSprite;
    }

    public void OnDisable()
    {
        button.GetComponent<Image>().sprite = DefaultSprite;
        button.GetComponent<Image>().raycastTarget = false;
        textImage.sprite = defaultTextSprite;
        textImage.enabled = true;
        button.interactable = true;
    }
}
