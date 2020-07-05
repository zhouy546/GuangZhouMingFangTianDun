using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerQARightAnswerBoard : MonoBehaviour
{

    public Animator animator;

    public Text AnswerText;

    public Text AnswerContentText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show() {
        animator.SetTrigger("show");
    }

    public void SetAnswerText(string s)
    {
        AnswerText.text = s;
    }

    public void SetAnswerContentText(string s) {
      string temp =  s.Remove(0, 2);

        AnswerContentText.text = temp;
    }
}
