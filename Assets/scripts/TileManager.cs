﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private float spawnZ =0;
    public Transform playerTransform;
    private float tileLenght = 22f;
    private int amountTilesOnScreen = 4;
    public List<GameObject> activeTiles;
   
    void Start()
    {
        for (int i = 0; i < amountTilesOnScreen; i++)
        {
            spawnTile();
        }

    }

    void Update()
    {
        //Debug.Log("Size is : "+tilePrefabs[1].GetComponentInChildren<MeshRenderer>().bounds.);
        if(playerTransform!=null)
        {
            if (spawnZ - playerTransform.position.z < 10f)
            {
               // moveTile();
                spawnTile();
                 deleteTile();
            }
        }
        
    }
    public void spawnTile(int prefabIndex = -1)
    {
        GameObject go;
        int rand = Random.Range(0, 3);
        go = Instantiate(tilePrefabs[rand]);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        //Debug.Log(spawnZ);
        //Debug.Log("TIle length:" + tileLenght);
        spawnZ += tileLenght;
        activeTiles.Add(go);
    }
    public void deleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    public void moveTile()
    {
        int rand = 2;
        int previous = rand;
        
         rand = Random.Range(0, 3);
         if (rand==previous)
        {
            moveTile();
        } else
        {
            previous = rand;
            tilePrefabs[rand].transform.position = (new Vector3(0, 0, spawnZ));
            tilePrefabs[rand].transform.SetParent(transform);
            spawnZ += tileLenght;
        }
        
    }
   
}
