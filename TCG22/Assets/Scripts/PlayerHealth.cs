using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth = 100;
    private HealthBar hpBar;
    public bool isAlive = true;

    // Start is called before the first frame update
    /*void Start()
    {
        hpBar.MaxHealth(playerHealth);
    }*/

    // Update is called once per frame
    void Update()
    {
        // Check if player is still alive
        if (playerHealth <= 0)
        {
            isAlive = false;
            playerHealth = 0;
            hpBar.SetHealth(0);
        }
    }

    public void setHPBar(HealthBar healthBar)
    {
        this.hpBar = healthBar;
        hpBar.MaxHealth(playerHealth);
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        hpBar.SetHealth(playerHealth);
    }

    public void Death()
    {
        this.TakeDamage(playerHealth);
    }
}
