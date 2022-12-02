using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Manager : MonoBehaviour
{
    public Player_Manager pm;
    public bool itsTurn;

    private void Start()
    {
        pm = GetComponentInParent<Player_Manager>();
        itsTurn = false;
    }

    public void IncIndex()
    {
        //pm.unitIndex = (pm.unitIndex + 1) % pm.unitManagers.Count;
        itsTurn = false;
        pm.unitIndex++;
    }
}
