using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class buildSystem : MonoBehaviour
{
    private blockSystem blockSys;
    private Block currentBlock;
    private GameObject blockTemplate;
    private SpriteRenderer currentRend;
    private Rigidbody2D currentRigid; 
    [SerializeField]
    private LayerMask solidNoBuildLayer;
    [SerializeField]
    private LayerMask backingNoBuildLayer;
    private System.Random rand = new System.Random();
    private int random_number; 

    private int numberDR = 1;
    private string[,,,] RoomsDR = new string[,,,]
    {
        {
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungeon101_Tileset_94_backing"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            }
        }
    };

    private int numberLD = 1;
    private string[,,,] RoomsLD = new string[,,,]
    {
        {
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungeon101_Tileset_94_backing"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            }
        }
    };

    private int numberLU = 1;
    private string[,,,] RoomsLU = new string[,,,]
    {
        {
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungeon101_Tileset_94_backing"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            }
        }
    };

    private int numberUR = 1;
    private string[,,,] RoomsUR = new string[,,,]
    {
        {
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungeon101_Tileset_94_backing"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            }
        }
    };

    private int numberLUR = 1;
    private string[,,,] RoomsLUR = new string[,,,]
    {
        {
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungeon101_Tileset_94_backing"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            }
        }
    };

    private int numberUDR = 1;
    private string[,,,] RoomsUDR = new string[,,,]
    {
        {
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungeon101_Tileset_94_backing"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungeon101_Tileset_94_backing"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            }
        }
    };

    private int numberLDR = 1;
    private string[,,,] RoomsLDR = new string[,,,]
    {
        {
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungeon101_Tileset_94_backing"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            }
        }
    };

    private int numberLUD = 1;
    private string[,,,] RoomsLUD = new string[,,,]
    {
        {
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungeon101_Tileset_94_backing"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungeon101_Tileset_94_backing"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            }
        }
    };

    private int numberLUDR = 1;
    private string[,,,] RoomsLUDR = new string[,,,]
    {
        {
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungeon101_Tileset_94_backing"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungeon101_Tileset_94_backing"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"null", ""},{"null", ""},{"null", ""},{"null", ""},{"null", ""},
                {"block", "Dungon101_Tileset_4_solid"}
            },
            {
                {"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungeon101_Tileset_94_backing"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},{"block", "Dungon101_Tileset_4_solid"},
                {"block", "Dungon101_Tileset_4_solid"}
            }
        }
    };

    private void Awake()
    {
        //DrawRoom("UR", 18, 11, -8, 5);
        //DrawHause(4, 3, -8, 5); 
        DrawHause(10, 10, -26, -17); 
    }

    private void DrawHause(int longX, int longY, int startX, int startY)
    {
        for (int x = 0; x < longX; x++)
        {
            for (int y = 0; y < longY; y++)
            {
                if (x == 0 && y == 0)
                {
                    DrawRoom("UR", 18, 11, startX + (x * 18), startY + (y * 11)); 
                }
                else if (x == longX - 1 && y == 0)
                {
                    DrawRoom("LU", 18, 11, startX + (x * 18), startY + (y * 11)); 
                }
                else if (x == longX - 1 && y == longY - 1)
                {
                    DrawRoom("LD", 18, 11, startX + (x * 18), startY + (y * 11)); 
                }
                else if (x == 0 && y == longY - 1)
                {
                    DrawRoom("DR", 18, 11, startX + (x * 18), startY + (y * 11)); 
                }
                else if (x == 0)
                {
                    DrawRoom("UDR", 18, 11, startX + (x * 18), startY + (y * 11)); 
                }
                else if (x == longX - 1)
                {
                    DrawRoom("LUD", 18, 11, startX + (x * 18), startY + (y * 11)); 
                }
                else if (y == 0)
                {
                    DrawRoom("LUR", 18, 11, startX + (x * 18), startY + (y * 11)); 
                }
                else if (y == longY - 1)
                {
                    DrawRoom("LDR", 18, 11, startX + (x * 18), startY + (y * 11)); 
                }
                else
                {
                    DrawRoom("LUDR", 18, 11, startX + (x * 18), startY + (y * 11)); 
                }
            }
        }
    }

    private void DrawRoom(string name, double width, double height, double startX, double startY)
    {
        blockSys = GetComponent<blockSystem>();
        if (name == "LUDR")
        {
            random_number = rand.Next(numberLUDR); 
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsLUDR[random_number, x, y, 0] == "block")
                    {
                        Creating(RoomsLUDR[random_number, x, y, 1], x + startX, startY - y);
                    }
                }
            }
        }
        else if (name == "DR")
        {
            random_number = rand.Next(numberDR);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsDR[random_number, x, y, 0] == "block")
                    {
                        Creating(RoomsDR[random_number, x, y, 1], x + startX, startY - y);
                    }
                }
            }
        }
        else if (name == "LD")
        {
            random_number = rand.Next(numberLD);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsLD[random_number, x, y, 0] == "block")
                    {
                        Creating(RoomsLD[random_number, x, y, 1], x + startX, startY - y);
                    }
                }
            }
        }
        else if (name == "LU")
        {
            random_number = rand.Next(numberLU);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsLU[random_number, x, y, 0] == "block")
                    {
                        Creating(RoomsLU[random_number, x, y, 1], x + startX, startY - y);
                    }
                }
            }
        }
        else if (name == "UR")
        {
            random_number = rand.Next(numberUR);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsUR[random_number, x, y, 0] == "block")
                    {
                        Creating(RoomsUR[random_number, x, y, 1], x + startX, startY - y);
                    }
                }
            }
        }
        else if (name == "LUR")
        {
            random_number = rand.Next(numberLUR);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsLUR[random_number, x, y, 0] == "block")
                    {
                        Creating(RoomsLUR[random_number, x, y, 1], x + startX, startY - y);
                    }
                }
            }
        }
        else if (name == "UDR")
        {
            random_number = rand.Next(numberUDR);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsUDR[random_number, x, y, 0] == "block")
                    {
                        Creating(RoomsUDR[random_number, x, y, 1], x + startX, startY - y);
                    }
                }
            }
        }
        else if (name == "LDR")
        {
            random_number = rand.Next(numberLDR);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsLDR[random_number, x, y, 0] == "block")
                    {
                        Creating(RoomsLDR[random_number, x, y, 1], x + startX, startY - y);
                    }
                }
            }
        }
        else if (name == "LUD")
        {
            random_number = rand.Next(numberLUD);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsLUD[random_number, x, y, 0] == "block")
                    {
                        Creating(RoomsLUD[random_number, x, y, 1], x + startX, startY - y);
                    }
                }
            }
        }
    }

    private void Creating(string id, double x, double y)
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
        blockTemplate.transform.position = new Vector2((float)Math.Round(x), (float)Math.Round(y));
        if(currentBlock.isSolid)
        {
            blockTemplate.layer = 6; 
            blockTemplate.AddComponent<BoxCollider2D>();
            currentRigid = blockTemplate.AddComponent<Rigidbody2D>();
            currentRigid.gravityScale = 0;
            currentRigid.mass = 100000;
            currentRigid.collisionDetectionMode = CollisionDetectionMode2D.Continuous; 
        }
    }
}
