using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Caps the applications framerate to 90 frames per second
        Application.targetFrameRate = 90;
        //Screen.SetResolution(640, 480, true);
    }
}