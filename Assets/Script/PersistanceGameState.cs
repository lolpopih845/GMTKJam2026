using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistanceGameState : MonoBehaviour
{
    public static PersistanceGameState I;
    private int bestScore = 0;
    private HashSet<Tuple<int, int>> ListOfPoisonousPair;

    void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }

        I = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
    }

}