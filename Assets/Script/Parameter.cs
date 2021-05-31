using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameter : MonoBehaviour
{
    public GameLogic GL;
    public GameObject cardGO;

    // UI Fill
    public Image Money_fill;
    public Image Mental_fill;
    public Image Health_fill;

    // UI Dot
    public Image Money_dot;
    public Image Mental_dot;
    public Image Health_dot;
    public int big;
    public int small;

    public float speed = 0.001f;

    void Awake()
    {
        GL = GameObject.Find("GameManager").GetComponent<GameLogic>();
    }
    void Start()
    {
        big = 10;
        small = 5;
        Money_fill.fillAmount = 0;
        Mental_fill.fillAmount = 0;
        Health_fill.fillAmount = 0;
    }
    void Update()
    {
        // FILL
        // Fill Money
        if (Money_fill.fillAmount > GameLogic.Money)
        {
            Money_fill.fillAmount -= speed;
        }
        else if (Money_fill.fillAmount < GameLogic.Money)
        {
            Money_fill.fillAmount += speed;
        }
        else if (Money_fill.fillAmount == GameLogic.Money)
        {
            Money_fill.fillAmount += 0f;
        }
        // Fill Mental
        if (Mental_fill.fillAmount > GameLogic.Mental)
        {
            Mental_fill.fillAmount -= speed;
        }
        else if (Mental_fill.fillAmount < GameLogic.Mental)
        {
            Mental_fill.fillAmount += speed;
        }
        else
        {
            Mental_fill.fillAmount = GameLogic.Mental;
        }
        // Fill Health
        if (Health_fill.fillAmount > GameLogic.Health)
        {
            Health_fill.fillAmount -= speed;
        }
        else if (Health_fill.fillAmount < GameLogic.Health)
        {
            Health_fill.fillAmount += speed;
        }
        else
        {
            Health_fill.fillAmount = GameLogic.Health;
        }

        // DOT
        if (cardGO.transform.position.x < -GL.fsidemargin) //Left
        {
            if (GL.currentCard.money_left == big || GL.currentCard.money_left == -big) //Money
            {
                Money_dot.transform.localScale = new Vector3(1.25f, 1.25f, 0);
            }
            else if (GL.currentCard.money_left == small || GL.currentCard.money_left == -small)
            {
                Money_dot.transform.localScale = new Vector3(1f, 1f, 0);
            }

            if (GL.currentCard.mental_left == big || GL.currentCard.mental_left == -big) //Mental
            {
                Mental_dot.transform.localScale = new Vector3(1.25f, 1.25f, 0);
            }
            else if (GL.currentCard.mental_left == small || GL.currentCard.mental_left == -small)
            {
                Mental_dot.transform.localScale = new Vector3(1f, 1f, 0);
            }

            if (GL.currentCard.health_left == big || GL.currentCard.health_left == -big) //Health
            {
                Health_dot.transform.localScale = new Vector3(1.25f, 1.25f, 0);
            }
            else if (GL.currentCard.health_left == small || GL.currentCard.health_left == -small)
            {
                Health_dot.transform.localScale = new Vector3(1f, 1f, 0);
            }
        }
        else if (cardGO.transform.position.x > GL.fsidemargin) // Right
        {
            if (GL.currentCard.money_right == big || GL.currentCard.money_right == -big) //Money
            {
                Money_dot.transform.localScale = new Vector3(1.25f, 1.25f, 0);
            }
            else if (GL.currentCard.money_right == small || GL.currentCard.money_right == -small)
            {
                Money_dot.transform.localScale = new Vector3(1f, 1f, 0);
            }

            if (GL.currentCard.mental_right == big || GL.currentCard.mental_right == -big) //Mental
            {
                Mental_dot.transform.localScale = new Vector3(1.25f, 1.25f, 0);
            }
            else if (GL.currentCard.mental_right == small || GL.currentCard.mental_right == -small)
            {
                Mental_dot.transform.localScale = new Vector3(1f, 1f, 0);
            }

            if (GL.currentCard.health_right == big || GL.currentCard.health_right == -big) //Health
            {
                Health_dot.transform.localScale = new Vector3(1.25f, 1.25f, 0);
            }
            else if (GL.currentCard.health_right == small || GL.currentCard.health_right == -small)
            {
                Health_dot.transform.localScale = new Vector3(1f, 1f, 0);
            }
        }

        else
        {
            Health_dot.transform.localScale = new Vector3(0, 0, 0);
            Mental_dot.transform.localScale = new Vector3(0, 0, 0);
            Money_dot.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
