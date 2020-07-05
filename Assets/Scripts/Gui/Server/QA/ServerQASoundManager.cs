using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerQASoundManager : MonoBehaviour
{

    public AudioSource BGMAudioSource;
    public AudioClip BGMClip;


    public AudioSource CoundDownBeepAudioSource;
    public AudioClip CoundDownBeepClip;


    public AudioSource VirtorySoundAudioSource;
    public AudioClip VirtorySoundClip;


    public AudioSource RightAnswerAudioSource;
    public AudioClip RightAnswerSoundClip;

    public static ServerQASoundManager instance;




    private void Awake()
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

    public void  PlayBGM()
    {
        BGMAudioSource.Play();
    }

    public void StopBgm()
    {
        BGMAudioSource.Stop();
    }

    public void PlayCountDownBeep() {
        CoundDownBeepAudioSource.PlayOneShot(CoundDownBeepClip);
    }

    public void StopCountDownBeep() {
        CoundDownBeepAudioSource.Stop();
     }


    public void PlayVirtorySound()
    {
        VirtorySoundAudioSource.PlayOneShot(VirtorySoundClip);
    }

    public void StopVirtorySound()
    {
        VirtorySoundAudioSource.Stop();
    }

    public void PlayRightAnswer()
    {
        RightAnswerAudioSource.PlayOneShot(RightAnswerSoundClip);
    }

    public void StopRightAnswer()
    {
        RightAnswerAudioSource.Stop();
    }


}
