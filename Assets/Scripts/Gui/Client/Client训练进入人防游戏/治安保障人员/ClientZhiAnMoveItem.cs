using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClientZhiAnMoveItem : MonoBehaviour,IDragHandler,IDropHandler,IEndDragHandler
{
    public int id;

    public RectTransform parentRect;
  

    public void OnDrag(PointerEventData eventData)
    {
      //   Debug.Log(eventData.position);
        Vector3 pos = new Vector3(eventData.position.x - Screen.width/2-parentRect.transform.localPosition.x, eventData.position.y -Screen.height / 2 - parentRect.transform.localPosition.y);
            this.transform.localPosition = pos;

    }

    public void OnDrop(PointerEventData eventData)
    {
     
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

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hitAnyThing = Physics.Raycast(ray, out hit, 1000);
        if (hitAnyThing)
        {
            Debug.Log(hit.collider.gameObject.tag);


            if (hit.collider.gameObject.tag=="fireArea")
            {
                Debug.Log(hit.collider.gameObject.GetComponent<clientFangHuoFengQuNode>().isRightAnswer(id));
                if (hit.collider.gameObject.GetComponent<clientFangHuoFengQuNode>().isRightAnswer(id)) {
                    this.GetComponent<Image>().color = Color.gray;
                    this.GetComponent<Image>().raycastTarget = false;

                    Debug.Log("Right");
                }
                else
                {
                    this.GetComponent<Image>().color = Color.white;

                }

            }
        }


        this.transform.localPosition = Vector3.zero;
    }
}
