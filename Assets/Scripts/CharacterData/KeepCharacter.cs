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

    private void Update()
    {
        GameObject characterMenuData = GameObject.FindWithTag("SelectedCharacter");

        if (characterMenuData != null)
        {
            CharacterManager menuData = characterMenuData.GetComponent<CharacterManager>();
            CharacterManager dataUpdater = this.gameObject.GetComponent<CharacterManager>();
            SkinnedMeshRenderer textureData = characterMenuData.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer textureDataTransfer = this.gameObject.GetComponent<SkinnedMeshRenderer>();

            dataUpdater.selectedOption = menuData.selectedOption;
            textureDataTransfer.sharedMesh = textureData.sharedMesh;
            textureDataTransfer.sharedMaterial = textureData.sharedMaterial;
            Debug.Log("Updating");
        }

    }
    // You can add your custom logic here
}
