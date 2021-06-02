using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamelogicmainmenu : MonoBehaviour
{
    // Card Movement
    public float fMovingSpeed = 3f;
    public float fsidemargin;

    public GameObject card;
    public CardLogic cl;
    public SpriteRenderer sr;

    private void Start()
    {
        sr = card.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        //Moving
        if (Input.GetMouseButton(0) && cl.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.y = 0f;
            card.transform.position = pos;
        }
        else
        {
            card.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMovingSpeed);
        }
    }
}

