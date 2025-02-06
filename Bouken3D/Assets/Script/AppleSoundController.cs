using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSoundController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip appleGetSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AppleContoroller.appleGetSound)
        {
            audioSource.PlayOneShot(appleGetSound);
        }
        
    }
}
