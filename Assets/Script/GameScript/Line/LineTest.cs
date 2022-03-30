using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LineTest : NetworkBehaviour
{
    private GameObject[] allPlayer = { };
    [SerializeField] private Transform[] players;
    [SerializeField] private LineController line;

    [SerializeField]private Transform[] TEST;
    private LineTest lineTest;
    //public GameObject[] players;

    private bool isClick = false;
    /*public override void OnStartAuthority()
    {
        enabled = true;
        lineTest.GetComponent<LineTest>();
        TEST[0] = this.gameObject.transform;
    }*/
        private void Start()
    {
        line.gameObject.SetActive(true);
    }
    
    private void Update()
    {
        if(isClick == true)
        {
            Debug.Log($"Click . {this.gameObject.name}");
            /*TEST[0] = this.gameObject.transform;
            TEST[1] = gameObject.transform;*/
            lineTest.TEST[1] = gameObject.transform;
            line.SetUpLine(TEST);
            isClick = false;
        }
        LineControl();
    }
    private void LineControl()
    {
        /*allPlayer = GameObject.FindGameObjectsWithTag("Player");
        players = new Transform[allPlayer.Length];

        for (int i = 0; i < allPlayer.Length; i++)
        {
            players[i] = allPlayer[i].transform;
        }*/
        line.SetUpLine(players);
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;
            //TEST[1] = gameObject.//FindGameObjectWithTag("Player").transform;
            //line.SetUpLine(TEST);
        }
    }
    public void GetPlayer(Transform players)
    {
        TEST[1] = players;
    }
}
