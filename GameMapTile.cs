using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapTile 
{
    public GameObject objTile;
    public GameMapTile nextTile;
    public GameMapTile prevTile;

    public enum TileDirection {
        X1Z0,
        X0Z1,
        X_Z0,
        X0Z_
    }
    public enum TileSlope
    {
        UP,
        FLAT
    }

    public TileDirection tileDirection;
    public Vector3 GetTrDirVector(TileDirection dir)
    {
        if (dir == TileDirection.X0Z1)
        {
            return new Vector3(0, 0, Variables.XGrid);
        }
        if (dir == TileDirection.X0Z_)
        {
            return new Vector3(0, 0, -Variables.XGrid);
        }
        if (dir == TileDirection.X1Z0)
        {
            return new Vector3(Variables.XGrid, 0, 0);
        }
        if (dir == TileDirection.X_Z0)
        {
            return new Vector3(-Variables.XGrid, 0, 0);
        }
        return new Vector3(0, 0, Variables.XGrid);
    }
    public Vector3 GetTrSlopeVector(TileSlope tileSlope)
    {
        if(tileSlope == TileSlope.FLAT)
        {
            return Variables.YGrid*Vector3.zero;
        }
        else
        {
            return Variables.YGrid*Vector3.up;
        }
    }

    public TileSlope tileSlope;
    public bool isBridge;
    public bool isHurdle;
    public GameObject hurdle;
    public GameObstacle obstacle;
    public void SetObstacle(GameObject go)
    {
        this.obstacle = go.GetComponent<GameObstacle>();
    }
    public void SetFence(GameObject go)
    {
        hurdle = go;
    }
    public void PutTile(GameMapTile tile)
    {
        tile.nextTile = this;
        this.prevTile = tile;
       
        this.objTile.transform.position = tile.objTile.transform.position + GetTrDirVector(tileDirection) + GetTrSlopeVector(tileSlope);
        if (this.obstacle != null)
        {
            obstacle.PutObj(this);
        }
        if (this.hurdle != null)
        {
            hurdle.transform.position = objTile.transform.position;
            hurdle.transform.rotation = objTile.transform.rotation;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
