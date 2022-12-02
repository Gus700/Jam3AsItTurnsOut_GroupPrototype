using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Manager : MonoBehaviour
{
    public Game_Manager gm;
    public bool itsTurn;

    private void Start()
    {
        gm = GetComponentInParent<Game_Manager>();
        itsTurn = false;
    }

    public void IncIndex()
    {
        gm.unitIndex = (gm.unitIndex + 1) % gm.units.Count;
    }
}
