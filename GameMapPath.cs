using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapPath : MonoBehaviour
{
    public GameObject fencePrefab;
    public Revolver fenceRevolver;
    public GameObject tilePrefab;
    public Revolver tileRevolver;
    public GameObject obstPrefab;
    public Revolver obstRevolver;
    public GameObject bridgePrefab;
    public Revolver bridgeRevolver;
    public GameMapTile startTile;
    
   
    // Start is called before the first frame update
    void Start()
    {
        tileRevolver = new Revolver();
        bridgeRevolver = new Revolver();
        obstRevolver = new Revolver();
        fenceRevolver = new Revolver();
        tileRevolver.Initiate("grass_revolver",tilePrefab, 500);
        bridgeRevolver.Initiate("bridge_revolver", bridgePrefab, 200);
        obstRevolver.Initiate("chicken_revolver", obstPrefab, 250);
        fenceRevolver.Initiate("fence_revolver", fencePrefab, 250);
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {   
        GameMapTile lastTile = null;
        startTile = new GameMapTile();
        startTile.objTile = tileRevolver.LoadObject();
        lastTile = startTile;
        int nowDir = 0;
        for (int i = 0; i < 40; i++)
        {

            GameMapTile tile = new GameMapTile();
            
            float f = Random.Range(0, 1f);
            if (i > 2 && f < 0.25f) {
                //if (f < 0.125f)
                //{
                //    nowDir++;
                //}
                //else
                //{
                //    nowDir--;
                //}
                //if (nowDir < 0)
                //{
                //    nowDir += 4;
                //}
                //nowDir %= 4;

                nowDir = 1 - nowDir;
            }
            tile.tileDirection = (GameMapTile.TileDirection)nowDir;
            if (Random.Range(0, 1f) < 0.1f)
            {
                //다리
                tile.objTile = bridgeRevolver.LoadObject();
                tile.isBridge = true;
            }
            else 
            {
                tile.objTile = tileRevolver.LoadObject();
                if ( Random.Range(0, 1f) < 0.2f)
                {
                    //장애물
                   
                    tile.SetObstacle(obstRevolver.LoadObject());
                }
                else if (Random.Range(0, 1f) < 0.2f)
                {
                    //허들
                    tile.isHurdle = true;
                    tile.SetFence(fenceRevolver.LoadObject());
                }
            }
            if(lastTile.isBridge || tile.isBridge || tile.isHurdle)
            {
                tile.tileSlope = GameMapTile.TileSlope.FLAT;
            }
            else
            {
                tile.tileSlope = GameMapTile.TileSlope.UP;
            }
            tile.PutTile(lastTile);
            
            lastTile = tile;
        }
    }
    
}
