using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLogic : MonoBehaviour
{
    public GameObject card;
    public bool isMouseOver = false;
    public GameLogic GL;

    public void Awake()
    {
        GL = GameObject.Find("GameManager").GetComponent<GameLogic>();
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            GL.startPosX = mousePos.x - GL.card.transform.localPosition.x;

            isMouseOver = true;
        }
    }

    private void OnMouseUp()
    {
        isMouseOver = false;
    }
}
