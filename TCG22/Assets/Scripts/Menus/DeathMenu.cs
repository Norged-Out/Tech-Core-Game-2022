using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MenuEssentials
{
    public static bool hasLost = false;
    public GameObject deathMenu;
    public static DeathMenu instance;

    private void Awake()
    {
        hasLost = false;
        if (DeathMenu.instance == null) instance = this;
        else Destroy(gameObject);
    }
    public void GameOver()
    {
        Debug.Log("YOU DIED");
        hasLost = true;
        ToggleDeath();
    }

    void ToggleDeath()
    {
        deathMenu.SetActive(!deathMenu.activeSelf);
    }
}
