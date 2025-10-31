using NUnit.Framework.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Data")]
    public Rigidbody2D rig;
    public PlayerGroundCheck groundCheck;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public double percent = 0;

    private IPlayerState currentState;
    private void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<PlayerGroundCheck>();
        SetState(new IdleState());
    }
    private void Update()
    {
        currentState.Update(this);
        currentState.HandleInput(this);
    }
    public void SetState(IPlayerState newState)
    {
        if (currentState != null)
        {
            currentState.Exit(this);
        }
        currentState = newState;
        currentState.Enter(this);
    }
}
