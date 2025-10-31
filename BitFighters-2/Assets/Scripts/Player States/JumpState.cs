using UnityEngine;

public class JumpState : IPlayerState
{
    public void Enter(PlayerController p)
    {
        p.rig.AddForce(new Vector2(0, p.jumpForce), ForceMode2D.Impulse);
        //Play Jumpsquat animation
        p.SetState(new AirIdleState());
    }
    public void Exit(PlayerController p)
    {

    }
    public void ForceExit(PlayerController p)
    {

    }
    public void Update(PlayerController p)
    {

    }
    public void HandleInput(PlayerController p)
    {
        
    }
}