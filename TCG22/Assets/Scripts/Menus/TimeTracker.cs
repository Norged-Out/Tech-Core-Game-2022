using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    public TextMeshProUGUI timeTracker;
    public GameObject player;
    private PlayerController controllerData;
    private float _ctMove;
    private float _ctAttack;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controllerData = player.GetComponent<PlayerController>();
        _ctMove = controllerData.movementTime;
        _ctAttack = controllerData.attackTime + _ctMove;
    }

    // Update is called once per frame
    void Update()
    {
        float reduction = 1 * Time.deltaTime;
        _ctMove -= reduction;
        _ctAttack -= reduction;

        timeTracker.text = "Time left to move: " + _ctMove.ToString("0");
        if (_ctMove <= 3) timeTracker.color = Color.red;
        if (_ctMove <= 0)
        {
            _ctMove = 0;
            timeTracker.text = "Time left to fire: " + _ctAttack.ToString("0");
            if (_ctAttack <= 5) timeTracker.color = Color.red;
            else timeTracker.color = Color.white;
            if (_ctAttack <= 0) _ctAttack = 0;
        }
    }
}
