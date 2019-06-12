using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blocksRemaining;

    public void CountBreakableBlocks()
    { 
            blocksRemaining++;

    }

    public void BlockDestroyed()
    {
        blocksRemaining--;
        if (blocksRemaining <= 0)
        {
            SceneLoader sceneloader = FindObjectOfType<SceneLoader>();
            sceneloader.loadNextScene();
        }
    }
}
