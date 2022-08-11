using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip terrainDestructionSound;
    public float terrainDestructionSoundVolume = 1;

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
}
