using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovementController : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    //[SerializeField] private CharacterController controller = null;
    [SerializeField]private Rigidbody2D rb;


    private Vector2 previosInput;
    private Controls controls;
    private Controls Controls
    {
        get
        {
            if (controls != null) { return controls; }
            return controls = new Controls();
        }
    }
    public override void OnStartAuthority()
    {
        enabled = true;

        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => ResetMovement();
    }
    [ClientCallback]
    private void OnEnable() => Controls.Enable();
    [ClientCallback]
    private void OnDisable() => Controls.Disable();
    [ClientCallback]
    private void FixedUpdate() => Move();
    
    [Client]
    private void SetMovement(Vector2 movement) => previosInput = movement;

    [Client]
    private void ResetMovement() => previosInput = Vector2.zero;

    [Client]
    private void Move()
    {
        Vector2 Horizontal = transform.right;
        Vector2 Vertical = transform.up;

        Vector2 movement = Horizontal.normalized * previosInput.x + Vertical.normalized * previosInput.y;
        //this.rb.velocity = movement * moveSpeed;
        //rb.velocity = movement * moveSpeed;
        rb.velocity = (movement * moveSpeed);

        //Vector2 Horizontal = controller.transform.right;
        //Vector2 Vertical = controller.transform.up;
        //controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}
