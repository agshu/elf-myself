using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfTouchInput : MonoBehaviour
{

    [SerializeField] AudioClip[] windowKnockingSounds;
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
            windowKnockSource.Play();
            
        }
    }
    //}
}
