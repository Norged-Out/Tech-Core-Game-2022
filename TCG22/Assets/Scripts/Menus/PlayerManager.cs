using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject currPlayer;
    public GameObject[] playerList;
    private GameObject playerA;
    private GameObject playerB;
    public Camera overviewCamera;
    public Camera playerCamera;

    private void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        playerA = playerList[0];
        playerB = playerList[1];
        currPlayer = playerA;
        playerB.gameObject.SetActive(false);
        playerCamera.GetComponent<FollowPlayer>().setPlayer(playerA);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && overviewCamera.enabled)
        {
            SwapPlayer();
        }
    }

    private void SwapPlayer()
    {
        if (playerA.activeSelf)
        {
            playerB.gameObject.SetActive(true);
            playerA.gameObject.SetActive(false);
            playerCamera.GetComponent<FollowPlayer>().setPlayer(playerB);
            playerB.GetComponent<PlayerController>().resetTimer();
        }
        else if (playerB.activeSelf)
        {
            playerA.gameObject.SetActive(true);
            playerB.gameObject.SetActive(false);
            playerCamera.GetComponent<FollowPlayer>().setPlayer(playerA);
            playerA.GetComponent<PlayerController>().resetTimer();
        }
    }
}
