using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] roadBlockPrefabs;
    private GameObject block;
    [SerializeField] private Transform playerTransf;
    List<GameObject> currentsBlocks = new List<GameObject>();

    private float startBlockXPos = 0,
                  blokLength = 0;
    private int blockCount = 25,
                safeZone = 30;

    void Start()
    {
        startBlockXPos = playerTransf.position.x;
        blokLength = 10;
        StartGame();
    }

    public void StartGame()
    {
        playerTransf.GetComponent<PlayerMovement>().ResetPosition();
        foreach (var go in currentsBlocks)
        {
            Destroy(go);
        }
        currentsBlocks.Clear();

        for (int i = 0; i < blockCount; i++)
        {
            if (i<3)
            {
                SpawnBlock(true);
            }
           else SpawnBlock(false);
        }
    }

    private void SpawnBlock(bool first)
    {
        if (first)
        {
            block = Instantiate(roadBlockPrefabs[0], transform);
        }
        else
         block = Instantiate(roadBlockPrefabs[Random.Range(0, roadBlockPrefabs.Length)], transform);
        Vector3 blockPos;

        if (currentsBlocks.Count > 0)
        {
            blockPos = currentsBlocks[currentsBlocks.Count - 1].transform.position + new Vector3(blokLength, 0, 0);
        }
        else
        {
            blockPos = new Vector3(startBlockXPos, 0, 0);
        }
        block.transform.position = blockPos;
        currentsBlocks.Add(block);
    }

    private void CheckForSpawn()
    {
        if (currentsBlocks[0].transform.position.x - playerTransf.position.x < -25)
        {
            SpawnBlock(false);
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        Destroy(currentsBlocks[0]);
        currentsBlocks.RemoveAt(0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckForSpawn();
    }
}
