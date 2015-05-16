using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DuckQueue : MonoBehaviour {

    int queueLimit = 3;
    int currNrOfDucks = 0;

    float minDuckSpawnDelay = 1f;
    float maxDuckSpawnBias = 1f;
    float nextDuckSpawnTime = 0;

    [SerializeField] GameObject duckPrefab;
    [SerializeField] Vector3[] ducksSittingPositions;
    Transform canvas;
    Counter counter;

    // place on the table, duck
    Dictionary<int, GameObject> duckList = new Dictionary<int, GameObject>();
    bool lastTimeCheckedWasFull = false;

	void Start()
    {
        canvas = GameObject.Find("Canvas").transform;
        nextDuckSpawnTime = Time.realtimeSinceStartup + minDuckSpawnDelay;
	}
	
	void Update()
    {
        if (IsReadyToSpawn())
            SpawnDuck();
	}

    void SpawnDuck()
    {
        print("spawning duck");

        currNrOfDucks++;
        int freePlace = GetFreePlace();

        GameObject duckObject = duckList[freePlace] = GameObject.Instantiate(duckPrefab);
        // duck usage
        Duck duck = duckObject.GetComponent<Duck>();

        duckObject.transform.SetParent(transform);
        duckObject.transform.position = ducksSittingPositions[freePlace];

        duck.burger = GrillTest.CreateRandomBurger();
        counter.AddOrder(duck.burger);
    }

    void RemoveDuck(int i)
    {
        Destroy(duckList[i]);
        currNrOfDucks--;
    }

    int GetFreePlace()
    {
        for (int i = 0; i < queueLimit; i++)
        {
            if (!duckList.ContainsKey(i))
                return i;
        }
        return 0;
    }

    bool IsReadyToSpawn()
    {
        if (currNrOfDucks < queueLimit)
        {
            if (lastTimeCheckedWasFull) // to prevent duck adding to queue immediately after one leave
            {
                nextDuckSpawnTime += minDuckSpawnDelay + Random.Range(0f, maxDuckSpawnBias);
                lastTimeCheckedWasFull = false;
            }
            else if (Time.realtimeSinceStartup >= nextDuckSpawnTime)
            {
                nextDuckSpawnTime = Time.realtimeSinceStartup + minDuckSpawnDelay + Random.Range(0f, maxDuckSpawnBias);
                return true;
            }
        }
        else
            lastTimeCheckedWasFull = true;
        return false;
    }
}
