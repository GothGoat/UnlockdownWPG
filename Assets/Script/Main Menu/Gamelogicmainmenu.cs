using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Gamelogicmainmenu : MonoBehaviour
{
    // Card Movement
    public float fMovingSpeed = 3f;
    public float fsidemargin;
    public float startPosX;
    public bool isMouseOver = false;

    public GameObject card;
    public SpriteRenderer sr;

    public TMP_Text Text;
    public string leftText;
    public string rightText;

    // Loading Screen
    public GameObject loadingScreen;

    // Name Input
    public GameObject inputField;
    public GameObject warningText;
    public GameObject nameField;

    public void Update()
    {
        if (card.transform.position.x > 0.5)    // Kanan
        {
            Text.text = rightText;
            Text.alpha = Mathf.Min(card.transform.position.x, 1);
            if (Input.GetMouseButtonUp(0))
            {
                StoreName();
                if (Name.charName == "")
                {
                    warningText.SetActive(true);
                }
                else
                {
                    nameField.SetActive(false);
                    Debug.Log("code berhasil");
                    StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
                    // SceneManager.GetActiveScene().buildIndex + 1
                }
            }
        }
        else if (card.transform.position.x < -0.5) // Kiri
        {
            Text.text = leftText;
            Text.alpha = Mathf.Min(-card.transform.position.x, 1);
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("QUIT");
                Application.Quit();
            }
        }
        else
        {
            Text.alpha = Mathf.Min(card.transform.position.x, 0);
        }

        //Moving
        if (isMouseOver)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            card.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, 0);
        }
        else
        {
            card.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMovingSpeed);
        }

        //Warna
        if (card.transform.position.x > 0.5)
        {
            sr.color = Color.green;
        }
        else if (card.transform.position.x < -0.5)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.white;
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            startPosX = mousePos.x - card.transform.localPosition.x;

            isMouseOver = true;
        }
    }

    private void OnMouseUp()
    {
        isMouseOver = false;
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);

            yield return null;
        }
    }

    public void StoreName()
    {
        Name.charName = inputField.GetComponent<Text>().text;
    }

}


