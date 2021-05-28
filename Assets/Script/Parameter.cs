using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameter : MonoBehaviour
{
    GameLogic Gl;
    public Image Health;
    public Image Mental;
    public Image Money;
    public float speed = 0.01f;

    void Awake()
    {
        Gl = GameObject.Find("GameManager").GetComponent<GameLogic>();
    }
    // Update is called once per frame
    void Update()
    {
        // Health
        if (Health.fillAmount < Gl.Health)
        {
            while (Health.fillAmount != Gl.Health)
            {
                Health.fillAmount += speed;
            }
        }
        else if (Health.fillAmount > Gl.Health)
        {
            while (Health.fillAmount != Gl.Health)
            {
                Health.fillAmount -= speed;
            }
        }
        else
        {
            Health.fillAmount = Gl.Health;
        }

        // Mental
        if (Mental.fillAmount < Gl.Mental)
        {
            Mental.fillAmount += speed;
        }
        else if (Mental.fillAmount > Gl.Mental)
        {
            Mental.fillAmount -= speed;
        }
        else
        {
            Mental.fillAmount = Gl.Health;
        }

        // Money
        if (Money.fillAmount < Gl.Money)
        {
            Money.fillAmount += speed;
        }
        else if (Money.fillAmount > Gl.Money)
        {
            Money.fillAmount -= speed;
        }
        else
        {
            Money.fillAmount = Gl.Health;
        }
    }
}
