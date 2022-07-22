using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEssentials : MonoBehaviour
{
    public int currSceneIndex;

    private void Update()
    {
        currSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Replay()
    {
        StartCoroutine(this.LoadLevel(currSceneIndex));
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel(currSceneIndex + 1));
    }

    protected IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        //transition.ResetTrigger("Start");
        SceneManager.LoadScene(levelIndex);
    }

    public void ReturnToStart()
    {
        StartCoroutine(LoadLevel(0));
    }
}
