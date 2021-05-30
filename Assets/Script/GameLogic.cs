using System.Collections;
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

    // Card Movement
    public float fMovingSpeed = 3f;
    public float fsidemargin;
    public float fsidetrigger;

    // UI
    public TMP_Text carddialoguetext;
    public TMP_Text dialogue;
    public Image dialogue_box;
    public Text Month;

    // Card Variables
    private string leftdialogue;
    private string rightdialogue;
    public Card currentCard;
    private string cardDialogue;
    private int deck_length;
    private int month_count = 1;

    // Card flip
    public Vector3 cardRotation;
    public Vector3 Currentrotation;
    public Vector3 Initialrotation;
    public bool isFliping = false;
    public float fRotatingSpeed;
    public Sprite cardBack;

    // Parameter
    public static int Money;
    public static int Health;
    public static int Mental;
    public static int maxValue = 100;
    public static int minValue = 0;

    void Start()
    {
        deck_length = resourceManager.cards.Length - 1;
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
                NewCard();
                Health.fillAmount += 1.0f / currentCard.health_left;
                Mental.fillAmount += 1.0f / currentCard.mental_left;
                Money.fillAmount += 1.0f / currentCard.money_left;
                
                Month.text = month_count++ + " M";
            }
        }
        else if (card.transform.position.x > fsidemargin)   // Right
        {
            dialogue.text = rightdialogue;
            dialogue.alpha = Mathf.Min(card.transform.position.x, 1);
            dialogue_box.CrossFadeAlpha(1, 0.1f, true);
            if (Input.GetMouseButtonUp(0))
            {
                NewCard();
                Card.Right();
                Month.text = month_count++ + " M";
                
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
            card.transform.eulerAngles = new Vector3(0, 0, 0);
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
