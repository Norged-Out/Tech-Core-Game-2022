using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    public TextMeshProUGUI timeTracker;
    private string player;
    private float _ctMove;
    private float _ctAttack;
    private bool timerActive = false;

    void Update()
    {
        if (!timerActive) return;
        if (_ctAttack <= 0) return;

        float reduction = 1 * Time.deltaTime;
        
        if (_ctMove <= 0)
        {
            _ctAttack -= reduction;
            timeTracker.text = "Time left for " +  player + " to fire: " + _ctAttack.ToString("0");
            if (_ctAttack <= 5) timeTracker.color = Color.red;
            else timeTracker.color = Color.white;
           // if (_ctAttack <= 0) _ctAttack = 0;
        }
        else
        {
            _ctMove -= reduction;
            timeTracker.text = "Time left for " + player + " to move: " + _ctMove.ToString("0");
            if (_ctMove <= 3) timeTracker.color = Color.red;
        }
    }


    public void setTimer(float moveTime, float attackTime, string playerName)
    {
        if (!timerActive) timerActive = true;
        _ctMove = moveTime;
        _ctAttack = attackTime;
        player = playerName;
    }
}
