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

    public List<GameObject> units;

    public List<Unit_Manager> unitManagers;

    public int unitIndex;

    private void Start()
    {
        units = new();
        unitIndex = 0;

        foreach (var player in players)
        {
            foreach (Transform child in player.transform)
            {
                units.Add(child.gameObject);
            }
        }
    }

    private void Update()
    {
        //units[playerIndex].GetComponent<Unit_Manager>().itsTurn = true;

        for (int i = 0; i < unitManagers.Count; i++)
        {
            if (i == unitIndex)
            {
                unitManagers[i].itsTurn = true;
            }
            else
            {
                unitManagers[i].itsTurn = false;
            }
        }
    }
}
