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
    private string[,,,] RoomsLUDR = new string[,,,]
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
        blockSys = GetComponent<blockSystem>();
        for(int x = 0; x < 39; x++)
        {
            for(int y = 0; y < 39; y++)
            {
                if (RoomsLUDR[0, x, y, 0] == "block")
                {
                    Creating(RoomsLUDR[0, x, y, 1], x, y); 
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
