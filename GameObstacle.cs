using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObstacle : MonoBehaviour
{
    public void ResetObstacle()
    {
        
    }
    public void PutObj(GameMapTile tile)
    {
        ResetObstacle();
        transform.position = tile.objTile.transform.position;
        transform.rotation = tile.objTile.transform.rotation;
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
