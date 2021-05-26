using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public TMP_Text display;
    public TMP_Text carddialoguetext;
    public TMP_Text dialogue;

    // Card Variables
    private string leftdialogue;
    private string rightdialogue;
    public Card currentCard;
    public Card testCard;
    private string cardDialogue;
    private int deck_length;

    void Start()
    {
        deck_length = resourceManager.cards.Length - 1;
        sr = card.GetComponent<SpriteRenderer>();
        LoadCard(testCard);

    }

    void Update()
    {
        //Check Side
        if (card.transform.position.x < -fsidetrigger)
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                NewCard();
            }
        }
        else if (card.transform.position.x > fsidetrigger)
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                NewCard();
            }
        }

        if (card.transform.position.x > fsidemargin)    //Kanan
        {
            dialogue.text = rightdialogue;
            dialogue.alpha = Mathf.Min(card.transform.position.x, 1);
        }
        else if (card.transform.position.x < -fsidemargin)   //Kiri
        {
            dialogue.text = leftdialogue;
            dialogue.alpha = Mathf.Min(-card.transform.position.x, 1);
        }
        else
        {
            dialogue.alpha = Mathf.Min(card.transform.position.x, 0);
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
            CardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
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
        for (int i = nilai_acak; i < deck_length - 1; i++)
        {
            resourceManager.cards[i] = resourceManager.cards[i + 1];
        }
        deck_length--;
    }
}
