using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip terrainDestructionSound;
    public AudioClip missionCompletedSound;
    public AudioClip youWinSound;

    public float terrainDestructionSoundVolume = 1;
    public float missionCompletedSoundVolume = 1;
    public float youWinSoundVolume = 1;

    private AudioSource soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playTerrainDestructionSound()
    {
        soundPlayer.PlayOneShot(terrainDestructionSound, terrainDestructionSoundVolume);
    }

    public void playGameOverSound()
    {
        soundPlayer.PlayOneShot(missionCompletedSound, missionCompletedSoundVolume);
        StartCoroutine(ParallelSoundClip());
    }

    IEnumerator ParallelSoundClip()
    {
        yield return new WaitForSeconds(2);
        soundPlayer.PlayOneShot(youWinSound, youWinSoundVolume);
    }
}
