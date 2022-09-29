using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn;
    public float tileLength;
    public int numberofTiles;
    private List<GameObject> activeTiles = new List<GameObject>();
    public static int tilesgenrated;

    public Transform[] playerTransform;

    public bool bosschk = true;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberofTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length-1));
            }
        }
        tilesgenrated = 4;

        Debug.Log("V Value: "+CameraController.v);
    }

    // Update is called once per frame
    void Update()
    {
        //Here 35 is the safe zone after reaching that the tile will be deleted
        if (playerTransform[CameraController.v].position.z -35> zSpawn - (numberofTiles * tileLength) && (tilesgenrated<=10))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length-1));
            DeleteTile();
        }
        else if (tilesgenrated==11 && bosschk)
        {
            SpawnBoss();
            bosschk = false;
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go= Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
        tilesgenrated++;
        Debug.Log("SpawnTile Worked");
    }

    public void SpawnBoss()
    {
        GameObject go = Instantiate(tilePrefabs[4], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
