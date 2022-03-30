using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerLineController : MonoBehaviour
{
    //private GameObject[] allPlayer = { };
    [SerializeField] private Transform[] players;
    [SerializeField] private LineController line;
    //public GameObject[] players;

    private bool isClick = false;

    private void Start()
    {
        players = new Transform[2];
        players[0] = this.gameObject.transform;
        line.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (isClick == true)
        {
            line.gameObject.SetActive(false);
            players[1] = gameObject.transform;
            //players[1] = gameObject.transform;
            isClick = false;
        }
        LineControl();
    }
    private void LineControl()
    {
        //allPlayer = GameObject.FindGameObjectsWithTag("Player");
        // players = new Transform[allPlayer.Length];

        /*for (int i = 0; i < allPlayer.Length; i++)
        {
            players[i] = allPlayer[i].transform;
        }*/
        line.SetUpLine(players);
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            isClick = true;
        }
    }
}