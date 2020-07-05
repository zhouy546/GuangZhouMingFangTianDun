using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerQAUnit : MonoBehaviour
{
   public Text SeatNumText;
   //public Text RightNumText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string Seat,string Right)
    {
        SeatNumText.text = (int.Parse(Seat)+1).ToString();
     //   RightNumText.text = Right;
    }

    public void Show()
    {
        SeatNumText.color = new Color(SeatNumText.color.r, SeatNumText.color.g, SeatNumText.color.b, 255f);
    }

    public void Hide() {
        SeatNumText.color = new Color(SeatNumText.color.r, SeatNumText.color.g, SeatNumText.color.b, 0f);

    }
}
