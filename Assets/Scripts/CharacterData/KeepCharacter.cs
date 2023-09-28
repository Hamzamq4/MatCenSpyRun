using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCharacter : MonoBehaviour
{
    private static KeepCharacter instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this as the instance
            instance = this;
            // Don't destroy this object when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }

    // You can add your custom logic here
}
