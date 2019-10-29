using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float _timer;
    public float _timeBtwSpawn;
    public Transform[] SpawnPoints;

    void Start()
    {
        _timeBtwSpawn = 2f;
    }
    private void Awake()
    {
        SpawnPoints = gameObject.GetComponentsInChildren<Transform>();
        BlockPool.Instance.AddObjects(20);
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeBtwSpawn)
        {
            Debug.Log("Spawntime");
            int notToSpawn = (int)Random.Range(1f, 5f);
            for (int i = 0; i < SpawnPoints.Length - 1; i++)
            {
                if (i != notToSpawn)
                {
                    Debug.Log(i);
                    Block block = BlockPool.Instance.Get();
                    block.transform.position = SpawnPoints[i+1].transform.position;
                    block.transform.rotation = Quaternion.identity;                    
                    block.gameObject.SetActive(true);
                }
                //reset timer
                _timer = 0f;

            }
            //spawn object and calculate which not to spawn

        }
    }
}
