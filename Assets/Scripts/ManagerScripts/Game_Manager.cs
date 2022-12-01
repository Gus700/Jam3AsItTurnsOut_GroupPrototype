using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for handling the ingame logic.
/// It dictates when each player gets their turn to commit their actions
/// </summary>
public class Game_Manager : MonoBehaviour
{
    public struct Player
    {
        public Player_Manager playerManager;
        public string name;
        public GameObject[] units;
        public bool itsTurn;
    }

    [Tooltip("Array of players in the game that are inserted from the editor")]
    [SerializeField] GameObject[] players;

    [Tooltip(
        "List of Player struct objects that will be handled by this component. " +
        "This list is a core member of the game logic"
    )]
    public List<Player> Players { get; private set; }

    [Tooltip(
        "Keeps track of how many players have finished their turn. " +
        "Once the list count reaches the same number of players in Players, " +
        "the round has finished and a new round will begin"
    )]
    public List<string> PlayersDone { get; private set; }

    [Tooltip("The current round number")]
    public int Round { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var player in players)
        {
            // Get Player_Manager component from player
            Player_Manager pm = player.GetComponent<Player_Manager>();

            // Instantiate a new Player struct object
            Player p = new()
            {
                playerManager = pm,
                name = pm.playerName
            };
            
            // Add the new Player to the Player List _players
            Players.Add(p);
        }

        // First player on the list goes first
        Players[0].playerManager.CanPlay = true;

        // Initialize PlayersDone
        PlayersDone = new();
    }

    // Update is called once per frame
    void Update()
    {
        // Iterate over each player to see if they have finished their turns
        for (int i = 0; i < Players.Count; i++)
        {
            Player currentPlayer = Players[i];

            // If currentPlayer finished their turn, increment PlayersDone
            if (currentPlayer.playerManager.FinishedTurn) 
            {
                // Check if Game_Manager has not added this player to the PlayersDone list
                if (!PlayersDone.Exists(x => x == currentPlayer.name))
                {
                    currentPlayer.playerManager.CanPlay = false;
                    PlayersDone.Add(currentPlayer.name);
                }
            }

            // If currentPlayer did not finish their turn,
            // check the conditions of the previous player
            else
            {
                // If the previous player finished their turn,
                // signal that it is currentPlayer's turn 
                if (i - 1 > -1 && 
                    Players[i - 1].playerManager.FinishedTurn
                )
                {
                    currentPlayer.playerManager.CanPlay = true;
                }
            }
        }

        // If PlayersDone is equal to Players.Count, then all players have completed their turns
        // and will start a new round with each player's conditions reset to default
        if (PlayersDone.Count == Players.Count)
        {
            Round++; // increment round number
            PlayersDone.Clear(); // empty PlayersDone

            // reset each player's conditions
            foreach (var player in Players)
            {
                ResetPlayerStatus(player.playerManager);
            }

            // first player on the list starts the new round first
            Players[0].playerManager.CanPlay = true;
        }
    }

    /// <summary>
    /// Resets the player's action and status conditions
    /// so they can commit actions again when it is their turn.
    /// This function was defined in Game_Manager to reiterate that
    /// the Game_Manager dictates when it is the player's turn.
    /// </summary>
    private void ResetPlayerStatus(Player_Manager pm)
    {
        pm.ResetUnitActions();
        pm.FinishedTurn = false;
    }
}
