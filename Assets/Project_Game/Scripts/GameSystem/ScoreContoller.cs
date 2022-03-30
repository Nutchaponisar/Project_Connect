using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;
public class ScoreContoller : NetworkBehaviour
{
    static ScoreContoller _instance;

    [SyncVar]
    private int _Score;

    void Awake() => _instance = this;


    [SerializeField] TMP_Text _ScoreText;

    void Update()
    {
        UpdateText();
    }
    void UpdateText()
    {
        _ScoreText.SetText(_Score.ToString());
    }

    public static void Add(int points)
    {
        _instance.AddPoints(points);
    }

    void AddPoints(int points)
    {
        _Score += points;
        UpdateText();
    }
}
