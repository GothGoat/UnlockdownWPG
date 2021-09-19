using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    public GameLogic GameLogic;
    public Karma karma;

    public float currentTime = 0f;
    public float startingTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

        // UI
        slider.maxValue = startingTime;
        slider.value = currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        slider.value = currentTime;
        if (currentTime <= 0)
        {
            GameLogic.iskarmaBad = true;
            karma.Impact();
            GameLogic.NewCard();
            GameLogic.Month.text = GameLogic.month_count++ + " M";
            if (GameLogic.iskarmaGood)
            {
                GameLogic.Health += Karma.badDebuff / 100f;
                GameLogic.Mental += Karma.badDebuff / 100f;
                GameLogic.Money += Karma.badDebuff / 100f;
            }
        }
    }
}
