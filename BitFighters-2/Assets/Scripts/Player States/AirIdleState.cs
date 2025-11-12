using UnityEngine;
public class AirIdleState : IPlayerState
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
        // Horizontal air movement
        float input = Input.GetAxis("Horizontal");
        p.rig.linearVelocity = new Vector2(input * p.moveSpeed, p.rig.linearVelocity.y);
    }
    public void HandleInput(PlayerController p)
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");
        bool attack = Input.GetButtonDown("Fire1");
        if (p.groundCheck.IsGrounded())
        {
            p.SetState(new IdleState());
        }
        if(attack)
        {
            p.SetState(new AttackState(inputx,inputy));
        }

    }

    public override string ToString()
    {
        return "AirIdleState";
    }
}
