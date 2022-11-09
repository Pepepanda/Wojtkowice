using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildSystem : MonoBehaviour
{
    private blockSystem blockSys;
    private Block currentBlock;
    private GameObject blockTemplate;
    private SpriteRenderer currentRend;
    [SerializeField]
    private LayerMask solidNoBuildLayer;
    [SerializeField]
    private LayerMask backingNoBuildLayer;

    private void Awake()
    {
        blockSys = GetComponent<blockSystem>();
        Creating("Dungon101_Tileset_5_solid", -3, -3);
        Creating("Dungon101_Tileset_4_solid", -2, -2);
        Creating("Dungon101_Tileset_6_solid", -1, 1);
        Creating("Dungon101_Tileset_5_solid", 2, 4);
    }

    private void Creating(string id, float x, float y)
    {
        for(int i = 0; i < blockSys.allBlocks.Length; i++)
        {
            if(blockSys.allBlocks[i].name == id)
            {
                currentBlock = blockSys.allBlocks[i];
                break; 
            }
        }
        blockTemplate = new GameObject("CurrentBlockTemplate");
        currentRend = blockTemplate.AddComponent<SpriteRenderer>();
        currentRend.sprite = currentBlock.sprite;
        blockTemplate.transform.position = new Vector2(x, y);
        int layer; 
        if(currentBlock.isSolid)
        {
            layer = LayerMask.NameToLayer("Solid Block");
        }
        else
        {
            layer = LayerMask.NameToLayer("Backing Block");
        }
        blockTemplate.layer = layer;
    }
}
