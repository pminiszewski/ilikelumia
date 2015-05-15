using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DuckQueue : MonoBehaviour {

    int queueLimit = 3;
    int currNrOfDucks = 0;

    float minDuckSpawnDelay = 5f;
    float nextDuckSpawnTime = 0;

    // place on the table, duck
    Dictionary<int, Duck> duckList;
    bool lastTimeCheckedWasFull = false;

	void Start ()
    {
        nextDuckSpawnTime = Time.realtimeSinceStartup + minDuckSpawnDelay;
	}
	
	void Update ()
    {
        if (IsReadyToSpawn())
            SpawnDuck();
	}

    void SpawnDuck()
    {
        int freePlace = GetFreePlace();
        duckList[freePlace] = new Duck();
    }

    int GetFreePlace()
    {
        for (int i = 0; i < queueLimit; i++)
        {
            if (duckList[i] == null)
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
                nextDuckSpawnTime += minDuckSpawnDelay;
                lastTimeCheckedWasFull = false;
            }
            else if (Time.realtimeSinceStartup >= nextDuckSpawnTime)
                return true;
        }
        else
            lastTimeCheckedWasFull = true;
        return false;
    }
}
