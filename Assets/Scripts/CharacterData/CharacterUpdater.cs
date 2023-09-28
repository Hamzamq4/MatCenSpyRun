using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpdater : MonoBehaviour
{
    public SkinnedMeshRenderer myTexture;
    // Start is called before the first frame update
    void Start()
    {
        GameObject characterData = GameObject.Find("CharacterDataTransfer");

        myTexture.sharedMesh = characterData.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        myTexture.sharedMaterial = characterData.GetComponent<SkinnedMeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
