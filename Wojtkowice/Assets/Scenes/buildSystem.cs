using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildSystem : MonoBehaviour
{
    private blockSystem blockSys;
    private int currentID = 0;
    private Block currentBlock;
    private GameObject blockTemplate;
    private SpriteRenderer currentRend;

    private void Awake()
    {
        blockSys = GetComponent<blockSystem>();
        currentBlock = blockSys.allBlocks[currentID];
        blockTemplate = new GameObject("CurrentBlockTemplate");
        currentRend = blockTemplate.AddComponent<SpriteRenderer>();
        currentRend.sprite = currentBlock.sprite; 
    }
}
