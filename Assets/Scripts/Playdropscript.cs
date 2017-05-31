using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playdropscript : MonoBehaviour {
    public AudioClip WaterDrop;
    private AudioSource source;

    void Start () {
        source = GetComponent<AudioSource>();

    }

    public void play()
    {
        source.PlayOneShot(WaterDrop, 1f);
    }

    //Plays a sound for a destroyed object.
}
