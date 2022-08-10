using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    public HealthBar hpBar;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.name.Equals("Player A"))
        {
            this.setHPBar(GameObject.Find("HealthBar A").GetComponent<HealthBar>());
        }
        else
        {
            this.setHPBar(GameObject.Find("HealthBar B").GetComponent<HealthBar>());
        }
    }

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
