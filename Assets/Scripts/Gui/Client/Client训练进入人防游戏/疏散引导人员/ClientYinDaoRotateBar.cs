using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ClientYinDaoRotateBar : MonoBehaviour,IDragHandler,IEndDragHandler,IPointerClickHandler
{

    private Vector2 BeginPoint;
    private Vector2 currentPoit;
    private float dis;

    private float tempval;

    private float val;

    public Image m_Image;

    public void OnPointerClick(PointerEventData eventData)
    {
        BeginPoint = eventData.position;
    }
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //}

    public void OnDrag(PointerEventData eventData)
    {
        currentPoit = eventData.position;

        dis = currentPoit.x - BeginPoint.x;

         tempval = dis * 0.5f;

        Debug.Log(tempval);

        this.transform.localRotation = Quaternion.Euler(0, 0, this.transform.localRotation.z - tempval);


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        val = val + tempval;

        if (val >= 1000)
        {
            m_Image.color = Color.gray;
            m_Image.raycastTarget = false;
        }

        BeginPoint = new Vector2(0, 0);
    }

    public void OnEnable()
    {
        m_Image.raycastTarget = true;
        m_Image.color = Color.white;

    }


    public void OnDisable()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
