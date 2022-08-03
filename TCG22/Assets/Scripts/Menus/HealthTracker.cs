using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthTracker : MonoBehaviour
{ 
    public TextMeshProUGUI healthTracker;
    public GameObject player;
    private PlayerController controllerData;
    private int _ctHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controllerData = player.GetComponent<PlayerController>();
        _ctHealth = controllerData.playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _ctHealth = controllerData.playerHealth;
        healthTracker.text = "Health: " + _ctHealth;

        if (_ctHealth <= 20) healthTracker.color = Color.yellow;
        else if (_ctHealth <= 10) healthTracker.color = Color.red;
        else if (_ctHealth <= 0)
        {
            _ctHealth = 0;
            healthTracker.color = Color.red;
        }
    }
}
