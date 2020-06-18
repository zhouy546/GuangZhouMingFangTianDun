using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsGroupCtr : MonoBehaviour
{
    public ArrowNode[] arrowNodes;

    public bool isRightAnswer;
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
        isRightAnswer = false;
    }

    public bool Check()
    {
        foreach (var item in arrowNodes)
        {
            if (item.isSelected != item.isRightAnswer)
            {
                isRightAnswer = false;
                return false;
            }
        }

        isRightAnswer = true;
        return true;
    }
}
