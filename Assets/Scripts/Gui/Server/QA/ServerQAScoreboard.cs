using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerQAScoreboard : MonoBehaviour
{

    public static ServerQAScoreboard instance;
    public Text m_text;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        Hide();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        m_text.color = new Color(255f, 255f, 255f, 255f);
    }

    public void Hide()
    {
        m_text.color = new Color(255f, 255f, 255f, 0f);

    }

    public void SetText(string s)
    {
        m_text.text = s;
    }
}
