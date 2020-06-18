using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientSelectBtn : MonoBehaviour
{
    public Sprite defaultSprite;
    public Image CharacterSprite;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDisable()
    {
        CharacterSprite.sprite = defaultSprite;
    }

}
