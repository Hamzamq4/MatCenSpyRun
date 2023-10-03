using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SkinnedMeshRenderer characterTexture;

    public int selectedOption;

    public bool isFemale;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter(selectedOption);

    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= characterDB.characterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.characterCount - 1;
        }

        UpdateCharacter(selectedOption);
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        
        characterTexture.sharedMesh = character.characterTexture.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        characterTexture.sharedMaterial = character.characterTexture.GetComponent<SkinnedMeshRenderer>().sharedMaterial;

        switch (selectedOption)
        {
            case 0:
                isFemale = false;
                break;
            case 1:
                isFemale = false;
                break;
            case 2:
                isFemale = true;
                break;
            case 3:
                isFemale = false;
                break;
            case 4:
                isFemale = false;
                break;
            case 5:
                isFemale = true;
                break;
            case 6:
                isFemale = false;
                break;
            case 7:
                isFemale = true;
                break;
            case 8:
                isFemale = false;
                break;
            case 9:
                isFemale = false;
                break;
            case 10:
                isFemale = false;
                break;
            case 11:
                isFemale = false;
                break;
            case 12:
                isFemale = false;
                break;
            case 13:
                isFemale = false;
                break;
            case 14:
                isFemale = true;
                break;
        }
    }
}
