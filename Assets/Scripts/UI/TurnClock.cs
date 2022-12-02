using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnClock : MonoBehaviour
{
    [SerializeField] List<Player_Manager> players;
    [SerializeField] TextMeshProUGUI _timerText;
    private string _playerName;
    private float _time;

    // Update is called once per frame
    void Update()
    {
        _timerText.SetText($"{_playerName}'s Turn\n{_time:0.0}");
    }

    public void PrintTime(
        string playerName,
        float time
    )
    {
        _playerName= playerName;
        _time= time;
    }
}
