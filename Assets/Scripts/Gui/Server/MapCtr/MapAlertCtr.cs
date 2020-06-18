using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAlertCtr : MonoBehaviour
{
    public static MapAlertCtr instance;

    public Animator m_animation;

    public MediaPlayer mediaPlayer;

    public DisplayUGUI displayUGUI;

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGroundVideo()
    {
        mediaPlayer.Play();

        displayUGUI.color = new Color(255f, 255f, 255f, 255f);

    }

    public void StopGroundVideo() {
        mediaPlayer.Stop();

        displayUGUI.color = new Color(255f, 255f, 255f, 0f);
    }


    public void Show() {
        Debug.Log("Running");
        m_animation.SetBool("Show", true);

    }

    public void Hide()
    {
        m_animation.SetBool("Show", false);
    }
}
