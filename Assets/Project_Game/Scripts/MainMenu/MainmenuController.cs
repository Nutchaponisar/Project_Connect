using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainmenuController : MonoBehaviour
{
    public void ChangeToCreateLobby()
    {
        SceneManager.LoadScene("CreateLobby");
    }
}
