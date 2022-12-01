using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    [Tooltip("Name of the player")]
    public string playerName { get; private set; }

    [Tooltip("The units this player has at the start of the game")]
    public GameObject[] Units { get; private set; }

    [Tooltip("If the Game_Manager declared it is this player's turn to play")]
    public bool CanPlay { get; set; }

    [Tooltip("Signals if the player has made all their available moves and finished their turn")]
    public bool FinishedTurn { get; set; }

    [Tooltip("If the player has used their move action")]
    public bool CanMove { get; set; }

    [Tooltip("If the player has used their shoot action")]
    public bool CanShoot { get; set; }

    private void Awake()
    {
        CanPlay = false;
        CanMove = true;
        CanShoot = true;
        FinishedTurn = false;
    }

    private void Update()
    {
        if (!CanMove && !CanShoot)
        {
            FinishedTurn = true;
        }
    }
}
