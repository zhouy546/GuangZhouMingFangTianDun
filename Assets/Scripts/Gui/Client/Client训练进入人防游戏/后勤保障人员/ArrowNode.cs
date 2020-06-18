using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowNode : MonoBehaviour
{
    public Image image;
    public ArrowNode node;

    public bool isRightAnswer;

    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        image.enabled = true;
        isSelected = false;

    }

    public void OnClick()
    {
        image.color = new Color(255f,255f, 255f, 255f);
        node.DeActivate();

        isSelected = true;
    }

    public void OnDisable()
    {

        image.enabled = false;
        isSelected = false;

    }

    public void DeActivate() {

        image.color = new Color(255f, 255f, 255f, 0f);
        isSelected = false;

    }

}
