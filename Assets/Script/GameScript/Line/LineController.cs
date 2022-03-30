using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineController : MonoBehaviour
{
    private LineRenderer line;
    private Transform[] players;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] players)
    {
        line.positionCount = players.Length;
        this.players = players;
    }
    private void Update()
    {
        for(int i = 0; i < players.Length; i++)
        {
            line.SetPosition(i, players[i].position);
        }
    }
}
