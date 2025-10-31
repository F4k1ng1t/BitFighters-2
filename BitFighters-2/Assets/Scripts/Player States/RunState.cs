using UnityEngine;

public class RunState : IPlayerState
{
    int _direction;
    public RunState(bool direction)
    {
        _direction = direction ? 1 : -1;
    }
    public void Enter(PlayerController p)
    {
        Debug.Log("Bruh, I'm running");
    }
    public void Exit(PlayerController p)
    {
        Debug.Log("Bruh I stopped running");

    }
    public void ForceExit(PlayerController p)
    {
        //Call if you are hit out of this state
    }
    public void Update(PlayerController p)
    {
        p.rig.linearVelocity = new Vector2(_direction * p.moveSpeed, p.rig.linearVelocity.y);
    }
    public void HandleInput(PlayerController p)
    {
        float input = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");
        //Change direction
        if (input * _direction < 0)
        {
            p.rig.linearVelocity = new Vector2(0, p.rig.linearVelocity.y);
            p.SetState(new RunState(input > 0));
        }
        if(Mathf.Abs(input) < 0.01f)
        {
            p.rig.linearVelocity = new Vector2(0, p.rig.linearVelocity.y);
            p.SetState(new IdleState());
        }
        if(jump > 0)
        {
            p.SetState(new JumpState());
        }
    }
}
