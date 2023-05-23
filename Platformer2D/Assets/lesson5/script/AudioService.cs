using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    [SerializeField] AudioClip[] heroClips;
    [SerializeField] AudioClip[] envClips; 
    [SerializeField] AudioClip[] enemyClips; 
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(heroClips[0]);
    }
    public void PlayStep1()
    {
        audioSource.PlayOneShot(heroClips[1]);
    }

    public void PlayStep2()
    {
        audioSource.PlayOneShot(heroClips[2]);
    }

    public void PlayShoot()
    {
        audioSource.PlayOneShot(heroClips[3]);
    }
    
    public void PlayBarrelBomb()
    {
        audioSource.PlayOneShot(envClips[0]);
    }



}
