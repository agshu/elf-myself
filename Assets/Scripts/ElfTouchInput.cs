using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ElfTouchInput : MonoBehaviour
{

    [SerializeField] AudioClip[] windowKnockingSounds;
    private AudioClip windowKnock;
    AudioSource windowKnockSource;

    void Awake()
    {
        windowKnockSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            UnityEngine.Debug.Log("Kocking on window!");
            windowKnock = windowKnockingSounds[UnityEngine.Random.Range(0, windowKnockingSounds.Length)];
            windowKnockSource.clip = windowKnock;
            windowKnockSource.Play();
            
        }
    }
}
