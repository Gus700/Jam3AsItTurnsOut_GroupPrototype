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
    public int P1score;
    public int P2score;
    public float turnTime;

    public List<Player_Manager> playerManagers;

    public int playerIndex;

    private void Start()
    {
        P1score = 0;
        P2score = 0;
        playerManagers = new();
        playerIndex = 0;

        foreach (var player in players)
        {
            playerManagers.Add(
                player.GetComponent<Player_Manager>()
            );
        }
    }

    private void Update()
    {
        for (int i = 0; i < players.Count; i++)
        {
            playerManagers[i].playerTurn = i == playerIndex;
        }
    }
}
