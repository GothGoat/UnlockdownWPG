using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu: MonoBehaviour
{
    public GameObject subMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubMenu ()
    {
        if (subMenu.activeInHierarchy == false)

        {
            subMenu.SetActive(true);
        }
        else
        {
            subMenu.SetActive(false);
        }
    }
}
