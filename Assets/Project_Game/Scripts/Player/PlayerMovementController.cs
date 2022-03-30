using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerMovementController : NetworkBehaviour
{
    public float playerMoveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator; // for future
    public GameObject PlayerModel;

    Vector2 move;
    private void Start()
    {
        PlayerModel.SetActive(false);
    }

    public void Movement()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

       /* float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0, yDirection);

        transform.position += moveDirection * speed;*/
    }
    private void Update()
    {
       if(SceneManager.GetActiveScene().name == "Game")
        {
            if(PlayerModel.activeSelf == false)
            {
                SetPosition();
                PlayerModel.SetActive(true);
            }
        }
        if (hasAuthority)
        {
            Movement();
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * playerMoveSpeed * Time.fixedDeltaTime);
    }
    public void SetPosition()
    {
        transform.position = new Vector3(Random.Range(-3, 3), 0, Random.Range(-0, 0));
    }
}
