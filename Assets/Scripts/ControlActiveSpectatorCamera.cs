using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ControlActiveSpectatorCamera : MonoBehaviour
{
    private Vector2 startPos;

    public int pixelDistanceToSwipe = 200;
    private bool fingerDown;

    public GameObject[] ElfCams;

    private int currentCamIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        ChangeActiveCamera(currentCamIndex);
        //ElfCam1.SetActive(true);
        //ElfCam2.SetActive(false);
        //ElfCam3.SetActive(false);
        //ElfCam4.SetActive(false);
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
            if (Input.touches[0].position.y >= startPos.y + pixelDistanceToSwipe)
            {
                fingerDown = false;
                UnityEngine.Debug.Log("Swipe up");
            }
            else if (Input.touches[0].position.x <= startPos.x - pixelDistanceToSwipe)
            {
                fingerDown = false;
                //ElfCam1.SetActive(false);
                //ElfCam2.SetActive(true);

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
                //ElfCam1.SetActive(true);
                //ElfCam2.SetActive(false);
                UnityEngine.Debug.Log("Swipe right");
            }
        }

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
        }
    }

    void ChangeActiveCamera(int newCamIndex)
    {
        for (int i = 0; i < ElfCams.Length; i++)
        {
            if (i != newCamIndex)
            {
                ElfCams[i].SetActive(false);
            }
        }
        ElfCams[newCamIndex].SetActive(true);
    }
}
