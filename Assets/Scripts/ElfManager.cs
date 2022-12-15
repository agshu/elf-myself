using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ElfManager : MonoBehaviour
{
    // Variables related to swipe on phone
    private Vector2 startPos;
    public int pixelDistanceToSwipe = 200;
    private bool fingerDown;

    // Variables related to spectator cameras
    public GameObject[] ElfCams;
    private int currentCamIndex = 0;

    // Variables related to windows and knocking sounds
    public GameObject[] Windows;
    public AudioClip[] windowKnockingSounds;
    private AudioClip windowKnock;
    AudioSource windowKnockSource;

    // Start is called before the first frame update
    void Start()
    {
        ChangeActiveCamera(currentCamIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if(fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;

            fingerDown = true;
        }

        if (fingerDown)
        {
            if (Input.touches[0].position.x <= startPos.x - pixelDistanceToSwipe)
            {
                fingerDown = false;
                if(currentCamIndex - 1 < 0)
                {
                    currentCamIndex = 3;
                    ChangeActiveCamera(currentCamIndex);
                }
                else
                {
                    currentCamIndex = currentCamIndex - 1;
                    ChangeActiveCamera(currentCamIndex);
                }
                UnityEngine.Debug.Log("Swipe left");
            }
            else if (Input.touches[0].position.x >= startPos.x + pixelDistanceToSwipe)
            {
                fingerDown = false;

                if (currentCamIndex + 1 > 3)
                {
                    currentCamIndex = 0;
                    ChangeActiveCamera(currentCamIndex);
                }
                else
                {
                    currentCamIndex = currentCamIndex + 1;
                    ChangeActiveCamera(currentCamIndex);
                }
                UnityEngine.Debug.Log("Swipe right");
            }
        }

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
            KnockOnWindow(currentCamIndex);
        }
    }

    void ChangeActiveCamera(int newCamIndex)
    {
        for (int i = 0; i < ElfCams.Length; i++)
        {
            if (i != newCamIndex)
            {
                ElfCams[i].GetComponent<AudioListener>().enabled = false;
                ElfCams[i].SetActive(false);
            }
        }
        ElfCams[newCamIndex].SetActive(true);
        ElfCams[newCamIndex].GetComponent<AudioListener>().enabled = true;
    }

    void KnockOnWindow(int windowIndex)
    {
        windowKnockSource = Windows[windowIndex].GetComponent<AudioSource>();

        UnityEngine.Debug.Log("Kocking on window!");
        windowKnock = windowKnockingSounds[UnityEngine.Random.Range(0, windowKnockingSounds.Length)];
        windowKnockSource.clip = windowKnock;
        windowKnockSource.Play();
    }
}
