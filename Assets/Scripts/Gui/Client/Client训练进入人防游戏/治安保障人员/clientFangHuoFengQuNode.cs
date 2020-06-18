using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientFangHuoFengQuNode : MonoBehaviour
{

    public int id;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isRightAnswer(int _id) {
        if (id == _id)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
