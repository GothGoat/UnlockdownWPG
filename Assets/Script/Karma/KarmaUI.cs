using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarmaUI : MonoBehaviour
{
    GameLogic GL;
    public static float badDebuff;
    public float gKarma_UI;
    public float bKarma_UI;

    private void Awake()
    {
        GL = GameObject.Find("GameManager").GetComponent<GameLogic>();
    }

    public void Start()
    {
        badDebuff = -20f;
    }

    public void Update()
    {
        if (gKarma_UI < GameLogic.good_karma)
        {
            // Make Icon Appear Here
            gKarma_UI++;
        }
        else if (gKarma_UI > GameLogic.good_karma)
        {
            // Make Icon disappear
            gKarma_UI--;
        }

        if (bKarma_UI < GameLogic.good_karma)
        {
            // Make Icon Appear Here
            bKarma_UI++;
        }
        else if (bKarma_UI > GameLogic.good_karma)
        {
            // Make Icon disappear
            bKarma_UI--;
        }
    }
    /* public void Impact()
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
    */
}
