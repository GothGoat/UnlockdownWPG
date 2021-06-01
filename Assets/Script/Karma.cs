using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karma : MonoBehaviour
{
    GameLogic GL;

    private void Awake()
    {
        GL = GameObject.Find("GameManager").GetComponent<GameLogic>();
    }
    public void Impact()
    {
        if (GameLogic.iskarmaGood)
            GL.Good.sprite = Resources.Load<Sprite>("Sprites/Good");
        else if (!GameLogic.iskarmaGood)
            GL.Good.sprite = Resources.Load<Sprite>("Sprites/Default");

        if (GameLogic.iskarmaBad)
            GL.Bad.sprite = Resources.Load<Sprite>("Sprites/Bad");
        else if (!GameLogic.iskarmaBad)
            GL.Bad.sprite = Resources.Load<Sprite>("Sprites/Default");

    }
}
