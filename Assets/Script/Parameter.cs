using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameter : MonoBehaviour
{
    public GameLogic GL;
    // UI Fill
    public Image Money_fill;
    public Image Mental_fill;
    public Image Health_fill;

    // UI Dot
    public Image Money_dot;
    public Image Mental_dot;
    public Image Health_dot;

    void Awake()
    {
        GL = GameObject.Find("GameManager").GetComponent<GameLogic>();
    }
    void Update()
    {
        // Fill 
        Money_fill.fillAmount = GameLogic.Money / GameLogic.maxValue;
        Mental_fill.fillAmount = GameLogic.Mental / GameLogic.maxValue;
        Health_fill.fillAmount = GameLogic.Health / GameLogic.maxValue;

    }
}
