using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Manager : MonoBehaviour
{
    [Tooltip("Player Manager component will be obtained via Start method (leave blank)")]
    public Player_Manager pm;
    public bool itsTurn;

    private void Start()
    {
        pm = GetComponentInParent<Player_Manager>();
        itsTurn = false;
    }

    public void IncIndex()
    {
        itsTurn = false;
        pm.unitIndex++;
    }
}
