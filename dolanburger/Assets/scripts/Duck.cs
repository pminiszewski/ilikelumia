using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Duck : MonoBehaviour {

    public enum DuckType
    {
        Normal,
        Mafia,
        Police
    }

    public struct Appearance
    {
        public int top;
        public int middle;
        public int bottom;
    }

    public Burger burger;
    public DuckType duckType;
    public Appearance appearance;

    void Start ()
    {
        duckType = GenerateDuckType();
        SetAppearance(0, 0, 0);
	}
	
	void Update ()
    {
	
	}

    DuckType GenerateDuckType()
    {
        DuckType duckType = (DuckType)Random.Range(0, 2);
        return duckType;
    }

    void SetAppearance(int top, int middle, int bottom)
    {
        appearance.top = top;
        appearance.middle = middle;
        appearance.bottom = bottom;
    }

}
