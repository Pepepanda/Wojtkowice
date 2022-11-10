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

    private string[,,,] RoomsDR = new string[,,,]
    {
        {
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "null", ""
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            },
            {
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungeon101_Tileset_94_backing"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                },
                {
                    "block", "Dungon101_Tileset_4_solid"
                }
            }
        }
    };

    private void Awake()
    {
        DrawRoom("DR", 18, 11, -8, -5); 
    }

    private void DrawRoom(string name, double width, double height, double startX, double startY)
    {
        blockSys = GetComponent<blockSystem>();
        if (name == "LUDR")
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsDR[0, x, y, 0] == "block")
                    {
                        Creating(RoomsDR[0, x, y, 1], x + startX, y + startY);
                    }
                }
            }
        }
        else if (name == "DR")
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (RoomsDR[0, x, y, 0] == "block")
                    {
                        Creating(RoomsDR[0, x, y, 1], x + startX, y + startY);
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
