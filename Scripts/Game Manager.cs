using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("_instance in the game manager is null!");
            }
            return _instance;
        }
    }

    public bool boughtKey { get; set; }
}
