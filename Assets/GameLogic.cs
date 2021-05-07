using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public GameObject card;
    public CardLogic cl;
    SpriteRenderer sr;
    public float fMovingSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        sr = card.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Moving
        if(Input.GetMouseButton(0) && cl.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.y = 0f;
            card.transform.position = pos;
        }
        else
        {
            card.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMovingSpeed);
        }
        

        //Check Side
        if(card.transform.position.x > 1.0)    //Kanan
        {
            sr.color = Color.cyan;
        }

        else if(card.transform.position.x < -1.0)   //Kiri
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.white;
        }
    }

}
