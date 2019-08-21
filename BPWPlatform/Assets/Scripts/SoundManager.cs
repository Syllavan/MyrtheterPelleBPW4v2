using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip stepSounds, jumpSounds, playerShoot, playerHit, playerHurt;
    static AudioSource audioScr;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        stepSounds = Resources.Load<AudioClip>("stepSounds");
        jumpSounds = Resources.Load<AudioClip>("jumpSounds");
        playerShoot = Resources.Load<AudioClip>("playerShoot");
        playerHit = Resources.Load<AudioClip>("playerHit");
        playerHurt = Resources.Load<AudioClip>("playerHurt");

        audioScr = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "stepSounds":
                audioScr.PlayOneShot(stepSounds);
                break;
            case "jumpSounds":
                audioScr.PlayOneShot(jumpSounds);
                break;
            case "playerShoot":
                audioScr.PlayOneShot(playerShoot);
                break;
            case "playerHit":
                audioScr.PlayOneShot(playerHit);
                break;
            case "playerHurt":
                audioScr.PlayOneShot(playerHurt);
                break;

        }

    }
}
