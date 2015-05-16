using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public static int nrOfFailures = 0;

	public Text TimeText;
	public Text FailuresText;
    public GameObject IntroScreen;
    private float _StartTime;
    private float _LerpTime;
    private bool _IntroStart;
    private Vector3 _StartPos;

    void Start ()
    {
		_StartTime = Time.realtimeSinceStartup;
	}

	void Update ()
    {

        if(_IntroStart)
        {
            IntroScreen.transform.localPosition = Vector3.Lerp(_StartPos, new Vector3(0,1920,0), _LerpTime);
            if (_LerpTime < 1)
            {
                _LerpTime += Time.deltaTime / 2.0f;
            }
        }

        if (TimeText != null)
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

    public void HideIntroScreenAndStartEverything()
    {
        _IntroStart = true;
        _StartPos = IntroScreen.transform.localPosition;
        StartCoroutine(StartThisShit());
    }

    IEnumerator StartThisShit()
    {
        yield return new WaitForSeconds(2.0f);
        _IntroStart = false;

    }
}
