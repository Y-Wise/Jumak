using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour
{
    public Character character;
    void awake()
    {
        DataMg.instance.currentCharacter = character;
    }

    
}
