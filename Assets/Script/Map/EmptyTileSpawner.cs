using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTileSpawner : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; ++i)
        {
            for (int j = 0; j < 100; ++j)
            {
                GameObject Tile = Instantiate(prefab);
                Tile.transform.position += new Vector3(i * 0.5f, 0.0f, j* 0.5f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
