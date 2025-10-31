using UnityEngine;

public class IdleState : IPlayerState
{
    public void Enter(PlayerController p)
    {

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
        float input = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");

        if (input < 0)
        {
            p.SetState(new RunState(false));
        }
        else if(input > 0)
        {
            p.SetState(new RunState(true));
        }
        if (jump > 0)
        {
            p.SetState(new JumpState());
        }
    }
}
