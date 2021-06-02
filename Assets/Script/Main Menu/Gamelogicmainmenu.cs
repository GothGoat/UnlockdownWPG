using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamelogicmainmenu : MonoBehaviour
{
    // Card Movement
    public float fMovingSpeed = 3f;
    public float fsidemargin;

    public GameObject card;
    public CardLogic cl;
    SpriteRenderer sr;

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

        //warna
        if (card.transform.position.x > fsidemargin)    // Kanan
        {
            sr.color = Color.green;
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene(1);
            }
        }
        else if (card.transform.position.x < -fsidemargin)  // Kiri
        {
            sr.color = Color.red;
            if (Input.GetMouseButtonUp(0))
            {
                Application.Quit();
                Debug.Log("Quit");
                // Quit Game
            }
        }
        else
        {
            sr.color = Color.white;
        }
    }
}

