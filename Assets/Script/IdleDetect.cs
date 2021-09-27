using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleDetect : MonoBehaviour
{
    public GameObject idleText;
    int IdleTimeSetting = 4;
    float LastIdleTime;

    void Awake()
    {
        LastIdleTime = Time.time;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            LastIdleTime = Time.time;
        }

        if (IdleCheck() == true)
        {
            idleText.SetActive(true);
            idleText.GetComponent<Animator>().enabled = true;
        }
        else
        {
            idleText.SetActive(false);
            idleText.GetComponent<Animator>().enabled = false;
        }
    }

    public bool IdleCheck()
    {
        return Time.time - LastIdleTime > IdleTimeSetting;
    }
}
