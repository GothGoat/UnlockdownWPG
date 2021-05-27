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
    public ResourceManager[] cards;
    public CardLogic cl;
    SpriteRenderer sr;

    // Card Movement
    public float fMovingSpeed = 3f;
    public float fsidemargin;
    public float fsidetrigger;

    // UI
    public TMP_Text carddialoguetext;
    public TMP_Text dialogue;
    public Image dialogue_box;
    public Image Health;
    public Image Mental;
    public Image Money;
    public Text Month;

    // Card Variables
    private string leftdialogue;
    private string rightdialogue;
    public Card currentCard;
    private string cardDialogue;
    private int deck_length;
    private int month_count = 1;

    void Start()
    {
        deck_length = resourceManager.cards.Length - 1;
        sr = card.GetComponent<SpriteRenderer>();
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
                Health.fillAmount += 1.0f / currentCard.health_right;
                Mental.fillAmount += 1.0f / currentCard.mental_right;
                Money.fillAmount += 1.0f / currentCard.money_right;
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
        else
        {
            card.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMovingSpeed);
        }
    }

    public void LoadCard(Card card)
    {
        if (deck_length == 0)
        {
            Debug.Log("Out of Card");
        }
        else
        {
            CardSpriteRenderer.sprite = card.sprite;
            leftdialogue = card.leftDialogue;
            rightdialogue = card.RightDialogue;
            carddialoguetext.text = card.cardDialogue;
            currentCard = card;
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
