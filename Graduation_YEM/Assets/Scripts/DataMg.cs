using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    CharGirl,CharBoy
}


public class DataMg : MonoBehaviour
{
    public static DataMg instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }

    public Character currentCharacter;
}
