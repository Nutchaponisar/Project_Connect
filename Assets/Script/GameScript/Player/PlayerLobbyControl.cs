using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class PlayerLobbyControl : MonoBehaviour
{
    void Update()
    {
        //Check for mouse click 
        /*if (Input.GetMouseButtonDown(0))
        {*/
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
           // }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
       // if (gameObject.tag == "Player")
       // {
            print(gameObject.name);
       // }
    }
}
