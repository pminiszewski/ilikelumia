using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DuckQueue : MonoBehaviour {

    int queueLimit = 3;
    int currNrOfDucks = 0;

    float minDuckSpawnDelay = 1f;
    float maxDuckSpawnBias = 1f;
    float nextDuckSpawnTime = 0;

    [SerializeField] GameObject scoreCard;
    [SerializeField] GameObject duckPrefab;
    [SerializeField] Vector3[] ducksSittingPositions;
    Transform canvas;
    Counter counter;

    // place on the table, duck
    Dictionary<int, GameObject> duckList = new Dictionary<int, GameObject>();
    bool lastTimeCheckedWasFull = false;

	void Start()
    {
        counter = FindObjectOfType<Counter>();
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
        duck.PlaceIndex = freePlace;
        duckObject.transform.SetParent(transform);
        //duckObject.transform.position = ducksSittingPositions[freePlace];
		Vector3 pos = ducksSittingPositions[freePlace];
		//pos.x = -20;
		duckObject.transform.position = pos;
		StartCoroutine(MoveTo(duck, ducksSittingPositions[freePlace]));

        duck.burger = GrillTest.CreateRandomBurger();
        //print("index: " + freePlace + ", burger items: " + duck.burger.Items.Count);
        counter.AddOrder(duck);
    }
	IEnumerator MoveTo(Duck d, Vector3 targetPos)
	{
		float dist = Vector3.Distance(transform.position, targetPos);
		while(dist > 0.01f)
		{

			d.transform.localPosition = Vector3.Lerp(d.transform.localPosition, targetPos, 0.001f * dist);
			yield return new WaitForSeconds(0.01f);
        }
		d.burger = GrillTest.CreateRandomBurger();
		counter.AddOrder(d);
    }

    public void RemoveDuck(int i)
    {
        Destroy(duckList[i]);
        duckList[i] = null;
        currNrOfDucks--;
    }

    public void RemoveDuck(Duck duck)
    {
        Destroy(duckList[duck.PlaceIndex]);
        duckList[duck.PlaceIndex] = null;
        currNrOfDucks--;
        //print("removing: " + duck.PlaceIndex);
    }

    public void ShowCard(Duck duck)
    {
        Vector3 cardPos = ducksSittingPositions[duck.PlaceIndex] + new Vector3(200, 300, 0);
        GameObject currDuckScoreCard = GameObject.Instantiate(scoreCard);
        currDuckScoreCard.transform.SetParent(canvas.transform);
        currDuckScoreCard.transform.position = cardPos;
        // set sprite
        currDuckScoreCard.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI_fail");
        // show only for few secs
        StartCoroutine(ShowingCard(currDuckScoreCard));
        print("show card");
    }

    IEnumerator ShowingCard(GameObject obj)
    {
        yield return new WaitForSeconds(2);
        print("destroy card");
        Destroy(obj);
    }

    int GetFreePlace()
    {
        for (int i = 0; i < queueLimit; i++)
        {
            if (!duckList.ContainsKey(i) || duckList[i] == null)
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
