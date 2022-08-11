using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsScreen : MonoBehaviour
{
    public GameObject results;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI winText;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void GameOverbyDeath(string winner, string loser)
    {
        soundManager.playGameOverSound();
        Debug.Log("Game Over");
        deathText.text = loser + " has Died";
        winText.text = winner + " has survived till the end";
        StartCoroutine(ToggleDeath());
    }

    public void GameOverbyTurns(int pAhealth, int pBhealth, string playerA, string playerB)
    {
        if(pAhealth > pBhealth)
        {
            winText.text = playerA + " has won with remaining health: " + pAhealth.ToString("0");
            deathText.text = playerB + " lost with " + pBhealth.ToString("0") + " health";
        }
        else
        {
            winText.text = playerB + " has won with remaining health: " + pBhealth.ToString("0");
            deathText.text = playerA + " lost with " + pAhealth.ToString("0") + " health";
        }
        results.SetActive(!results.activeSelf);
    }

    IEnumerator ToggleDeath()
    {        
        yield return new WaitForSeconds(2);
        results.SetActive(!results.activeSelf);
    }
}
