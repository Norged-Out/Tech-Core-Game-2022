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

    public void GameOver(string winner, string loser)
    {
        soundManager.playGameOverSound();
        Debug.Log("Game Over");
        deathText.text = loser + " has Died";
        winText.text = winner + " has survived till the end";
        StartCoroutine(ToggleDeath());
    }

    IEnumerator ToggleDeath()
    {        
        yield return new WaitForSeconds(2);
        results.SetActive(!results.activeSelf);
    }
}
