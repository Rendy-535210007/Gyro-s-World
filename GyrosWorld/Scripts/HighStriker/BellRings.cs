using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellRings : MonoBehaviour
{
    public AudioClip bellRingSFX;
    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = bellRingSFX;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            audioSrc.Play();
        }
    }
}
