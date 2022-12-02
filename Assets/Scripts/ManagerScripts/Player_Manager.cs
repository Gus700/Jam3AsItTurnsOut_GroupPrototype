using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    [SerializeField] UnitIndicator indicator;
    [SerializeField] TurnClock timer;
    public GameObject player;
    public Game_Manager gm;
    public int score;
    public int unitIndex;
    public bool playerTurn;
    public float timeRemaining;

    public List<(
        GameObject unit,
        Unit_Manager unitMan
    )> unitManagers;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        gm = GetComponentInParent<Game_Manager>();
        score = 0;
        unitIndex = 0;
        timeRemaining = gm.turnTime;

        unitManagers = new();

        foreach (Transform child in player.transform)
        {
            unitManagers.Add((
                child.gameObject,
                child.GetComponent<Unit_Manager>()
            ));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn) 
        {
            timer.PrintTime(gameObject.name, timeRemaining);

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                EndTurn();
            }

            if (unitIndex < unitManagers.Count)
            {
                for (int i = 0; i < unitManagers.Count; i++)
                {
                    unitManagers[i].unitMan.itsTurn = i == unitIndex;
                    if (unitManagers[i].unitMan.itsTurn)
                    {
                        indicator.TargetActiveUnit(
                            unitManagers[i].unitMan.gameObject.transform.position
                        );
                    } 
                }
            }
            else
            {
                EndTurn();
            }
        }
        
    }

    public void EndTurn()
    {
        playerTurn = false;
        unitIndex = 0;
        timeRemaining = gm.turnTime;
        gm.playerIndex = (gm.playerIndex + 1) % gm.players.Count;
    }
}
