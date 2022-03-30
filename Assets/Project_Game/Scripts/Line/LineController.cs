using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineController))]
public class LineController : MonoBehaviour
{
    /*private LineRenderer line;
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
        for (int i = 0; i < players.Length; i++)
        {
            line.SetPosition(i, players[i].position);
        }
    }*/
    private GameObject[] allPlayer;
    [SerializeField] List<Transform> players;
    private LineRenderer line;
    private bool forTest = false;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = players.Count;
    }

    private void Update()
    {
        LineSet();
        line.SetPositions(players.ConvertAll(n => n.position - new Vector3(0, 0, 5)).ToArray());
    }
    private void LineSet()
    {
        allPlayer = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < allPlayer.Length; i++)
        {   
            players[i] = allPlayer[i].transform;
        }
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[line.positionCount];
        line.GetPositions(positions);
        return positions;
    }

    public float GetWidth()
    {
        return line.startWidth;
    }
}