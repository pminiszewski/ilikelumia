using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Duck : MonoBehaviour {

    public enum DuckType
    {
        Normal,
        Mafia,
        Police
    }
    
    public Burger burger;
    public DuckType duckType;
    public int maxDuckAppearance;
    public int maxNormalAppearance;
    public int maxMafiaAppearance;
    public int maxPoliceAppearance;
    public int PlaceIndex;

    void Start ()
    {
        duckType = GenerateDuckType();
        SetAppearance();

    }

    void Update ()
    {
	
	}

    DuckType GenerateDuckType()
    {
        DuckType duckType = (DuckType)Random.Range(0, 3);
        return duckType;
    }

    public void SetAppearance()
    {
        int specialElement = Random.Range(0, 3);
        Image[] imgs = GetComponentsInChildren<Image>();

        string duck = "Duck/" + Random.Range(0, maxDuckAppearance-1);
        string normal = "Normal/" + Random.Range(0, maxNormalAppearance-1);
        string special = "";

        switch (duckType)
        {
            case DuckType.Mafia:
                //normal = "Normal/4";
                special = "Mafia/" + Random.Range(0, maxMafiaAppearance - 1);
                break;
            case DuckType.Police:
                //normal = "Normal/4";
                special = "Police/" + Random.Range(0, maxPoliceAppearance - 1);
                break;
            default:
                break;
        }

        imgs[0].sprite = Resources.Load<Sprite>(duck);

        imgs[1].sprite = Resources.Load<Sprite>(normal);
        imgs[2].sprite = Resources.Load<Sprite>(special);
    }
}
