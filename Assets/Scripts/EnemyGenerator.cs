using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;

    private int _numberOfEnemies = 3;
    private List<Vector3> _positions;

    private void Awake()
    {
        _numberOfEnemies = GamePlayController.EnemiesCount;
    }

    private void Start()
    {
        GeneratePositions();
        if (_positions.Count > 0)
            InstantiateEnemies();
    }

    private void GeneratePositions()
    {
        _positions = new List<Vector3>(_numberOfEnemies);

        RaycastHit hit;
        var terrrainSize = Terrain.activeTerrain.terrainData.size;
        var counter = 0;

        for (int i = 0; i < _numberOfEnemies; i++)
        {
            Vector3 position;
            bool found = false;

            do
            {
                position = new Vector3(1 + Random.Range(0f, 1f) * (terrrainSize.x - 2),
                                       1,
                                       1 + Random.Range(0f, 1f) * terrrainSize.z - 2);

                // check if the point is available
                if (Physics.Raycast(new Vector3(position.x, position.y + 10, position.z), Vector3.down, out hit))
                {
                    if (hit.transform.CompareTag("Terrain"))
                    {
                        found = true;
                    }
                }

                if (++counter > 1000 * _numberOfEnemies)
                {
                    Debug.LogError("Too many tries to generate random positions");
                    break;
                }

            } while (!found);

            _positions.Add(position);
        }

    }

    private void InstantiateEnemies() =>
        _positions.ForEach(position =>
        {
            var instantiatedEnemy = Instantiate(enemyPrefab) as GameObject;

            instantiatedEnemy.transform.position = new Vector3(position.x, 
                                                               instantiatedEnemy.transform.position.y,
                                                               position.z);
        });
    
}
