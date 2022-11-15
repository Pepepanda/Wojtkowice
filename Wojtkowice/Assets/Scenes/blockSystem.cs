using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSystem : MonoBehaviour
{
    //private Camera mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    public Block[] allBlocks;
    [SerializeField]
    private Sprite[] solidBlocks;
    [SerializeField]
    private string[] solidNames;
    [SerializeField]
    private Sprite[] backingBlocks;
    [SerializeField]
    private string[] backingNames;

    private void Awake()
    { 
        allBlocks = new Block[solidBlocks.Length + backingBlocks.Length];
        int newBlockId = 0;
        
        for (int i = 0; i < solidBlocks.Length; i++)
        {
            allBlocks[newBlockId] = new Block(newBlockId, solidNames[i], solidBlocks[i], true);
            Debug.Log("Solid block: allblock[" + newBlockId + "] = " + solidNames[i]);
            newBlockId++;
        }

        for (int j = 0; j < backingBlocks.Length; j++)
        {
            allBlocks[newBlockId] = new Block(newBlockId, backingNames[j], backingBlocks[j], false);
            Debug.Log("Solid block: allblock[" + newBlockId + "] = " + backingBlocks[j]);
            newBlockId++; 
        }
    }
}

public class Block
{
    public int id;
    public string name;
    public Sprite sprite;
    public bool isSolid;

    public Block(int myid, string myname, Sprite mysprite, bool isISolid)
    {
        this.id = myid;
        this.name = myname;
        this.sprite = mysprite;
        this.isSolid = isISolid;
    }
}