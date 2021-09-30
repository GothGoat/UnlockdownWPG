using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Card[] cards;
    public Card[] regularCards;
    public Card[] karmaCards;

    public int regularCardMax;
    public int karmaCardMax;

    public void Awake()
    {
        int regularCardsLength = regularCards.Length - 1;
        int karmaCardsLength = karmaCards.Length - 1;

        // Insert regular card to array
        for (int i = 0; i < regularCardMax; i++)
        {
            int random_regular = Random.Range(0, regularCardsLength-1);

            cards[i] = regularCards[random_regular];
            for (int j = random_regular; j < regularCardsLength; j++ )
            {
                regularCards[j] = regularCards[j + 1];
            }
            regularCardsLength--;
        }

        for (int i = regularCardMax ; i <= 36; i++)
        {
            int random_karma = Random.Range(0, karmaCardsLength-1);
            cards[i] = karmaCards[random_karma];
            for (int j = random_karma; j < karmaCardsLength; j++)
            {
                karmaCards[j] = karmaCards[j + 1];
            }
            karmaCardsLength--;
        }
    }
}


