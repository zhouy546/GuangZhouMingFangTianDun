using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerQADotsNode : MonoBehaviour
{
    public Image DotImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Color color)
    {
        DotImage.color = color;
    }

    public void Show()
    {
        DotImage.color = new Color(255, 255, 255, 255);
    }

    public void Hide()
    {
        DotImage.color = new Color(255, 255, 255, 0);

    }
}
