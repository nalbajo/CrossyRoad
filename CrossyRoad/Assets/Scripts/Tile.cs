using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public int visibleTiles = 15;
    public float tileLength = 1f;
    private float spawnZ = 0f;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform cameraTransform; // ī�޶� Transform�� ����

    void Start()
    {
        for (int i = 0; i < visibleTiles; i++)
            SpawnTile();
    }

    void Update()
    {
        // ī�޶� ���� ��ġ�� ��������� �� Ÿ�� ����
        if (cameraTransform.position.z > spawnZ - visibleTiles * tileLength)
        {
            SpawnTile();
            RemoveOldestTile();
        }
    }

    void SpawnTile()
    {
        GameObject prefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
        GameObject tile = Instantiate(prefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
        activeTiles.Add(tile);
        spawnZ += tileLength;
    }

    void RemoveOldestTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}

