using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playdropscript : MonoBehaviour {
    public AudioClip WaterDrop;
    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void play()
    {
        source.PlayOneShot(WaterDrop, 1f);
    }
}
