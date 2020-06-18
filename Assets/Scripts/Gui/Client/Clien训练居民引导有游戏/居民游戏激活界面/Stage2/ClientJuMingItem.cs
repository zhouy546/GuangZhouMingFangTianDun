using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClientJuMingItem : MonoBehaviour,IDragHandler,IDropHandler
{
    public Transform Parent;

    public bool ISItem =true;

    public BaoSlotCtr slotCtr;


    public void OnDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        //Debug.Log(eventData.position);

        Vector3 pos = new Vector3(eventData.position.x - Screen.width / 2 - Parent.transform.localPosition.x, eventData.position.y - Screen.height / 2 - Parent.transform.localPosition.y);
        this.transform.localPosition = pos;

    }

    public void OnDrop(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();

        if (isInBagArea(eventData.position)) {
            if (ISItem)
            {
                this.GetComponent<Image>().color = Color.gray;
                this.GetComponent<Image>().raycastTarget = false;
            }
            else
            {
                this.GetComponent<Image>().color = Color.white;
                slotCtr.TriggerAnim();
            }
        }


        this.transform.localPosition = Vector3.zero;
    }


    public void OnDisable()
    {
        this.GetComponent<Image>().color = Color.white;
        this.GetComponent<Image>().raycastTarget = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isInBagArea(Vector2 mousePose)
    {
        if (mousePose.x > 1300 && mousePose.x < 1900 && mousePose.y < 1000 && mousePose.y > 500)
        {
            return true;

        }
        else
        {
            return false;
        }
    }
}
