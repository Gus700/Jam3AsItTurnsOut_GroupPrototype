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
    //public int unitIndex;

    private void Start()
    {
        P1score = 0;
        P2score = 0;
        playerManagers = new();
        //unitManagers = new();
        playerIndex = 0;
        //unitIndex = 0;

        foreach (var player in players)
        {
            playerManagers.Add(player.GetComponent<Player_Manager>());
        }
        /*foreach (var player in players)
        {
            foreach (Transform child in player.transform)
            {
                unitManagers.Add((
                    child.gameObject, 
                    child.GetComponent<Unit_Manager>()
                ));
            }
        }*/
    }

    private void Update()
    {
        for (int i = 0; i < players.Count; i++)
        {
            playerManagers[i].playerTurn = i == playerIndex;
            //unitManagers[i].unitMan.itsTurn = i == unitIndex;
        }
    }
}
