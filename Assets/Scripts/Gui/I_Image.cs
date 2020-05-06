using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image),typeof(Animator))]
public class I_Image : MonoBehaviour
{
    public Image image;
    public Animator animator;
    // Start is called before the first frame update
    public virtual void Awake()
    {
        image=  this.GetComponent<Image>();
        animator =  this.GetComponent<Animator>();
        
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

    public virtual void ShowDisableOrActiveOne()
    {

    }

    public virtual void SetTick()
    {

    }
}
