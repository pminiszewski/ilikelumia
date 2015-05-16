using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public static int nrOfFailures = 0;

	public Text TimeText;
	public Text FailuresText;
	private float _StartTime;


	void Start ()
    {
		_StartTime = Time.realtimeSinceStartup;
	}

	void Update ()
    {
		if(TimeText != null)
		{
			TimeText.text = "Time: "+(Time.realtimeSinceStartup - _StartTime).ToString();
		}
		if(FailuresText)
		{
			FailuresText.text = "Failed deliveries: "+ nrOfFailures;
		}
	}

    static void Reset()
    {

    }

}
