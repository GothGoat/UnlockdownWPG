﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    // Game Objects
    public GameObject card;
    public SpriteRenderer CardSpriteRenderer;
    public ResourceManager resourceManager;
    public CardLogic cl;
    public Karma karma;

    // Card Movement
    public float fMovingSpeed = 3f;
    public float fsidemargin;

    // UI
    public TMP_Text carddialoguetext;
    public TMP_Text dialogue;
    public Image dialogue_box;
    public Text Month;

    // Card Variables
    [HideInInspector] public string leftdialogue;
    [HideInInspector] public string rightdialogue;
    public Card currentCard;
    [HideInInspector] public string cardDialogue;
    private int deck_length;
    public int month_count = 1;
    
    // Karma System
    public static bool iskarmaGood;
    public static bool iskarmaBad;
    public Image Good;
    public Image Bad;

    // Card flip
    [HideInInspector] public Vector3 cardRotation;
    [HideInInspector] public Vector3 Currentrotation;
    public Vector3 Initialrotation;
    [HideInInspector] public bool isFliping = false;
    public float fRotatingSpeed;
    public Sprite cardBack;

    // Parameter
    public static float Money = 1f;
    public static float Health = 1f;
    public static float Mental = 1f;
    public float maxValue = 1f;
    public float minValue = 0f;

    void Start()
    {
        deck_length = resourceManager.cards.Length - 1;
        iskarmaBad = false;
        iskarmaGood = false;
        NewCard();
        Month.text = "0 M";
    }

    void Update()
    {
        //Check Side
        if (card.transform.position.x < -fsidemargin)   // Left
        {
            dialogue.text = leftdialogue;
            dialogue.alpha = Mathf.Min(-card.transform.position.x, 1);
            dialogue_box.CrossFadeAlpha(1, 0.1f, true);
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                karma.Impact();
                if (!WinLose.GameOver)
                {
                    NewCard();
                    Month.text = month_count++ + " M";
                }
            }
        }
        else if (card.transform.position.x > fsidemargin)   // Right
        {
            dialogue.text = rightdialogue;
            dialogue.alpha = Mathf.Min(card.transform.position.x, 1);
            dialogue_box.CrossFadeAlpha(1, 0.1f, true);
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                karma.Impact();

                if (!WinLose.GameOver)
                {
                    NewCard();
                    Month.text = month_count++ + " M";
                }
            }
        }
        else
        {
            dialogue.alpha = Mathf.Min(card.transform.position.x, 0);
            dialogue_box.CrossFadeAlpha(0, 0.1f, true);
        }

        //Moving
        if (Input.GetMouseButton(0) && cl.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.y = 0f;
            card.transform.position = pos;
        }
        else if (!isFliping)
        {
            card.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMovingSpeed);
            
        }
        else if (isFliping)
        {
            card.transform.eulerAngles = Vector3.MoveTowards(card.transform.eulerAngles, cardRotation, fRotatingSpeed);
            if(card.transform.eulerAngles.y >= 90)
            {
                CardSpriteRenderer.sprite = cardBack;
            }
            else
            {
                CardSpriteRenderer.sprite = currentCard.sprite;
            }
        }

        // Rotating card
        if(card.transform.eulerAngles == cardRotation)
        {
            isFliping = false;
        }

        // Keep Parameter Max and Min
        if (Health > maxValue)
            Health = 1f;
        else if (Health < minValue)
            Health = 0f;

        if (Mental > maxValue)
            Mental = 1f;
        else if (Mental < minValue)
            Mental = 0f;

        if (Money > maxValue)
            Money = 1f;
        else if (Money < minValue)
            Money = 0f;
    }

    public void LoadCard(Card ncard)
    {
        if (deck_length == 0)
        {
            Debug.Log("Out of Card");
        }
        else
        {
            currentCard = ncard;
            CardSpriteRenderer.sprite = ncard.sprite;
            leftdialogue = ncard.leftDialogue;
            rightdialogue = ncard.RightDialogue;
            carddialoguetext.text = ncard.cardDialogue;

            // Reset card position
            card.transform.position = new Vector2(0, 0);
            card.transform.eulerAngles = new Vector3(0, 0, 0);
            
            isFliping = true;
            card.transform.eulerAngles = Initialrotation;
        }
    }

    public void NewCard()
    {
        if (iskarmaBad)
        {
            iskarmaBad = false;
            Debug.Log("Bad Deactivate");
        }

        int acak = Random.Range(0, deck_length);
        int nilai_acak = acak;
        LoadCard(resourceManager.cards[nilai_acak]);
        
        // Hapus kartu yang sudah muncul
        for (int i = nilai_acak; i < deck_length; i++)
        {
            resourceManager.cards[i] = resourceManager.cards[i + 1];
        }
        deck_length--;
    }
}
