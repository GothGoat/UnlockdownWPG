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
        card.transform.position = new Vector2(0, 0);
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

        if (card.transform.position.x > 0.5)
        {
            sr.color = Color.green;
        }
        else if (card.transform.position.x < -0.5)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.white;

        }

    }
    public void PlayGame()
    {

        //scene 
        if (card.transform.position.x > 0.5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }
}

