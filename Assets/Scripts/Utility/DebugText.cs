using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugText : MonoBehaviour
{
    public Text Text;

    public static DebugText instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setText(string s)
    {
        Text.text = s;
    }
}
