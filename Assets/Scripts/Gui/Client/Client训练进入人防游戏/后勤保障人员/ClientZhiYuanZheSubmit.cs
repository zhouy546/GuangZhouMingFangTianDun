using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientZhiYuanZheSubmit : MonoBehaviour
{
    public Button button;
    public GoodsGroupCtr[] goodsGroupCtrs;
    public ClientHouQingBaseGameActive clientHouQingBaseGameActive;
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
        button.interactable = true;
    }

    public void OnClick()
    {
        button.interactable = false;


        foreach (var item in goodsGroupCtrs)
        {
            item.Check();
        }

        foreach (var item in goodsGroupCtrs)
        {
            if (item.isRightAnswer == false)
            {
                //告诉服务器我选错了

            }
        }

        clientHouQingBaseGameActive.ShowStage2();

    }

}
