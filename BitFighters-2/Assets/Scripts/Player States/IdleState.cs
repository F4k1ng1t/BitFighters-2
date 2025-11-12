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
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");
        bool attack = Input.GetButtonDown("Fire1");
        bool jump = Input.GetButtonDown("Jump");

        if (inputx < 0)
        {
            p.SetState(new RunState(false));
            return;
        }
        else if(inputx > 0)
        {
            p.SetState(new RunState(true));
            return;
        }

        bool grounded = p.groundCheck != null && p.groundCheck.IsGrounded();
        if (jump && grounded)
        {
            p.SetState(new JumpState());
            return;
        }

        if(attack)
        {
            p.SetState(new AttackState(inputx, inputy));
        }
    }

    public override string ToString()
    {
        return "IdleState";
    }
}
