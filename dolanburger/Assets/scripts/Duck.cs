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

    public enum Parts
    {
        Top,
        Middle,
        Bottom
    }

    public Dictionary<Parts, Image> parts;

    [System.Serializable]
    public struct Appearance
    {
        public int top;
        public int middle;
        public int bottom;
    }

    public Burger burger;
    public DuckType duckType;
    public Appearance maxNormalAppearance;
    public Appearance maxMafiaAppearance;
    public Appearance maxPoliceAppearance;

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
        DuckType duckType = (DuckType)Random.Range(0, 2);
        return duckType;
    }

    public void SetAppearance()
    {
        int specialElement = Random.Range(0, 3);
        Image[] imgs = GetComponentsInChildren<Image>();

        string topStr = "Normal/top_" + Random.Range(0, maxNormalAppearance.top - 1);
        string middleStr = "Normal/middle_" + Random.Range(0, maxNormalAppearance.middle - 1);
        string bottomStr = "Normal/bottom_" + Random.Range(0, maxNormalAppearance.bottom - 1);

        switch (duckType)
        {
            case DuckType.Mafia:
                if(specialElement == 0)
                    topStr = "Mafia/top_" + Random.Range(0, maxMafiaAppearance.top - 1);
                else if(specialElement == 1)
                    middleStr = "Mafia/middle_" + Random.Range(0, maxMafiaAppearance.middle - 1);
                else if(specialElement == 2)
                    bottomStr = "Mafia/bottom_" + Random.Range(0, maxMafiaAppearance.bottom - 1);
                break;
            case DuckType.Police:
                if (specialElement == 0)
                    topStr = "Police/top_" + Random.Range(0, maxPoliceAppearance.top - 1);
                else if (specialElement == 1)
                    middleStr = "Police/middle_" + Random.Range(0, maxPoliceAppearance.middle - 1);
                else if (specialElement == 2)
                    bottomStr = "Police/bottom_" + Random.Range(0, maxPoliceAppearance.bottom - 1);
                break;
            default:
                break;
        }

        imgs[0].sprite = Resources.Load<Sprite>(topStr);
        imgs[1].sprite = Resources.Load<Sprite>(middleStr);
        imgs[2].sprite = Resources.Load<Sprite>(bottomStr);
    }

}
