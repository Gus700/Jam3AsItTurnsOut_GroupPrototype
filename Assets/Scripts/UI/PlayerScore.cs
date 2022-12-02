using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] Player_Manager pm;
    [SerializeField] string playerName;
    [SerializeField] TextMeshProUGUI _playerScore;

    public int score;

    private void Start()
    {
        score = 0;
        playerName = pm.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        score = pm.score;
        _playerScore.SetText($"{playerName}\u000a{score}");
    }
}
