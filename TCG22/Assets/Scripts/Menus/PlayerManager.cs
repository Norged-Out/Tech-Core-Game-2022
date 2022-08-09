using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] playerList;
    private GameObject playerA;
    private GameObject playerB;
    private PlayerController paController;
    private PlayerController pbController;
    private AnimationContoller paAnimator;
    private AnimationContoller pbAnimator;
    public HealthBar hpA;
    public HealthBar hpB;
    public Camera overviewCamera;
    public Camera playerCamera;
    public TimeTracker timeTracker;
    private int numTurns;

    private void Awake()
    {
        int _paIndex;
        int _pbIndex;
        do
        {
            _paIndex = Random.Range(0, 3);
            _pbIndex = Random.Range(0, 3);
        } while (_paIndex == _pbIndex);

        playerA = Instantiate(playerList[_paIndex]) as GameObject;
        playerB = Instantiate(playerList[_pbIndex]) as GameObject;


        paController = playerA.GetComponent<PlayerController>();
        pbController = playerB.GetComponent<PlayerController>();
        paController.playerCamera = playerCamera;
        paController.overviewCamera = overviewCamera;
        pbController.playerCamera = playerCamera;
        pbController.overviewCamera = overviewCamera;
        paController.hpBar = hpA;
        pbController.hpBar = hpB;
        playerA.name = "Player A";
        playerB.name = "Player B";
        paController.enabled = true;
        pbController.enabled = false;
        playerCamera.GetComponent<FollowPlayer>().setPlayer(playerA);
        numTurns = 1;
    }

    private void Start()
    {
        paAnimator = playerA.GetComponent<AnimationContoller>();
        pbAnimator = playerB.GetComponent<AnimationContoller>();
        pbAnimator.enabled = false;
    }

    private void Update()
    {
        if (!timeTracker.turnActive)            //Input.GetKeyDown(KeyCode.S) && overviewCamera.enabled)
        {
            if(numTurns < 6)
            {
                numTurns++;
                SwapPlayer();
            }
            else
            {
                timeTracker.timeTracker.text = "Game Over";
            }
        }
    }

    private void SwapPlayer()
    {
        if (paController.enabled == true)
        {
            pbController.enabled = true;
            paController.enabled = false;
            pbAnimator.enabled = true;
            paAnimator.enabled = false;
            playerCamera.GetComponent<FollowPlayer>().setPlayer(playerB);
            pbController.resetTimer();
        }
        else if (pbController.enabled == true)
        {
            paController.enabled = true;
            pbController.enabled = false;
            paAnimator.enabled = true;
            pbAnimator.enabled = false;
            playerCamera.GetComponent<FollowPlayer>().setPlayer(playerA);
            paController.resetTimer();
        }
    }
}
