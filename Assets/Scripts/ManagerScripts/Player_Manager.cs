using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public struct Unit
    {
        public Unit_Manager unitManager;
        public string name;
    }

    [Tooltip("Name of the player")]
    public string playerName { get; private set; }

    [Tooltip("The units this player has at the start of the game")]
    public GameObject[] units { get; private set; }

    [Tooltip("If the Game_Manager declared it is this player's turn to play")]
    public bool CanPlay { get; set; }

    [Tooltip("Signals if the player has made all their available moves and finished their turn")]
    public bool FinishedTurn { get; set; }

    [Tooltip("Holds all Unit struct objects. List is used to check the status of each unit")]
    public List<Unit> Units { get; private set; }

    public List<string> UnitsDone { get; private set; }


    private void Awake()
    {
        CanPlay = false;
        FinishedTurn = false;
    }

    private void Start()
    {
        for (int i = 0; i < units.Length; i++)
        {
            Unit u = new()
            {
                unitManager = units[i].GetComponent<Unit_Manager>(),
                name = units[i].name ?? "Unit_" + i
            };

            Units.Add(u);
        }

        // Initialize list
        UnitsDone = new();
    }

    private void Update()
    {
        // While the player has not signaled the end of their turn
        if (!FinishedTurn)
        {
            // Iterate over each unit controlled by the player
            foreach (var unit in Units)
            {
                // if the unit signals they no longer have any actions remaining,
                // add the unit to the UnitsDone list
                if (!unit.unitManager.HasActions)
                {
                    if (!UnitsDone.Exists(x => x == unit.name))
                    {
                        UnitsDone.Add(unit.name);
                    }
                }
            }
        }

        // Once the number of units added to the UnitsDone list
        // is equal to the number of Units controlled by the player,
        // the player will inform the Game_Manager that they finished
        // their turn
        if (UnitsDone.Count == Units.Count) 
        {
            FinishedTurn = true;
        }
    }

    // This function resets the status of the available actions
    // for each unit controlled
    public void ResetUnitActions()
    {
        foreach (var unit in Units)
        {
            unit.unitManager.ResetActions();
        }
    }
}
