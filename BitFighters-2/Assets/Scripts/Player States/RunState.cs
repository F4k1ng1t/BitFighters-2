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
        Debug.Log("I'm running");
    }
    public void Exit(PlayerController p)
    {
        Debug.Log("I stopped running");
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
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");
        bool attack = Input.GetButtonDown("Fire1");
        bool jump = Input.GetButtonDown("Jump");

        //Change direction
        if (inputx * _direction < 0)
        {
            p.rig.linearVelocity = new Vector2(0, p.rig.linearVelocity.y);
            p.SetState(new RunState(inputx > 0));
            return;
        }

        if (Mathf.Abs(inputx) < 0.01f)
        {
            p.rig.linearVelocity = new Vector2(0, p.rig.linearVelocity.y);
            p.SetState(new IdleState());
            return;
        }

        // Only allow jumping if the ground check reports grounded (null-safe)
        bool grounded = p.groundCheck != null && p.groundCheck.IsGrounded();
        if (jump && grounded)
        {
            p.SetState(new JumpState());
            return;
        }

        if (attack)
        {
            p.SetState(new AttackState(inputx, inputy));
            return;
        }
    }

    public override string ToString()
    {
        return _direction >= 0 ? "RunState(Right)" : "RunState(Left)";
    }
}
