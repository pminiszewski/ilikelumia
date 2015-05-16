using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Diamond : Item
{

    void Awake()
    {
        ThisIsDiaaaamond = true;
        if (ThisIsDiaaaamond)
        {
            GetComponent<Image>().sprite = GetDiamondImage();
        }
    }


}
