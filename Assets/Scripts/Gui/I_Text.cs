using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text), typeof(Animator))]
public class I_Text : MonoBehaviour
{
    public Text image;
    public Animator animator;
    public virtual void Awake()
    {
        image = this.GetComponent<Text>();
        animator = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Show()
    {
        animator.SetBool("Show", true);
    }

    public virtual void Hide()
    {
        animator.SetBool("Show", false);
    }
}
