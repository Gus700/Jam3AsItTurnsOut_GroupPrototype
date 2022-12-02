using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for handling the ingame logic.
/// It dictates when each player gets their turn to commit their actions
/// </summary>
public class Game_Manager : MonoBehaviour
{
    public List<GameObject> players;

    public List<(
        GameObject unit, 
        Unit_Manager unitMan
    )> unitManagers;

    public int unitIndex;

    private void Start()
    {
        unitManagers = new();
        unitIndex = 0;

        foreach (var player in players)
        {
            foreach (Transform child in player.transform)
            {
                unitManagers.Add((
                    child.gameObject, 
                    child.GetComponent<Unit_Manager>()
                ));
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < unitManagers.Count; i++)
        {
            unitManagers[i].unitMan.itsTurn = i == unitIndex;
        }
    }
}
