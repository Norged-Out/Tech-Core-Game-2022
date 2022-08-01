using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    public TextMeshProUGUI moveTimeTracker;
    public TextMeshProUGUI attackTimeTracker;
    public float timeToMove = 10f;
    public float timeToAttack = 30f;
    private float _ctMove;
    private float _ctAttack;

    void Awake()
    {
        _ctMove = timeToMove;
        _ctAttack = timeToAttack;
    }

    // Update is called once per frame
    void Update()
    {
        float reduction = 1 * Time.deltaTime;
        _ctMove -= reduction;
        _ctAttack -= reduction;

        moveTimeTracker.text = "Time left to move: " + _ctMove.ToString("0");
        if (_ctMove <= 3) moveTimeTracker.color = Color.red;
        if (_ctMove <= 0) _ctMove = 0;

        attackTimeTracker.text = "Time left to fire: " + _ctAttack.ToString("0");
        if (_ctAttack <= 5) attackTimeTracker.color = Color.red;
        if (_ctAttack <= 0) _ctAttack = 0;
    }
}
