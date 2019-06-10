using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blocksRemaining;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
