using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> tanks;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float spawnTime = 4f;
    
    private void Start()
    {

        StartCoroutine(SpawnTank());
    }

    IEnumerator SpawnTank()
    {
        while (true)
        {
            var limit = Stats.Level < tanks.Count ? Stats.Level : tanks.Count;

            Instantiate(tanks[Random.Range(0, limit)], spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void Update()
    {
        
    }
}
