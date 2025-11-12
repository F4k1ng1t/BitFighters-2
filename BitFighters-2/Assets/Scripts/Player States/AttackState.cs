using UnityEngine;

public class AttackState : IPlayerState
{
    (float x, float y) attack;
    string attackType = "";
    float duration = 0.2f; // seconds the attack state lasts
    float timer;
    bool wasGrounded; // buffer whether player was grounded at any point during the attack

    public AttackState(float horizontalDir, float verticalDir)
    {
        attack = (horizontalDir, verticalDir);
    }

    public void Enter(PlayerController p)
    {
        attackType = WhatAttack();
        timer = duration;

        // Initialize grounded buffer from current state
        wasGrounded = p.groundCheck != null && p.groundCheck.IsGrounded();

        Debug.Log($"Enter AttackState: {attackType} (wasGrounded={wasGrounded})");
    }

    public void Exit(PlayerController p)
    {
        
    }

    public void ForceExit(PlayerController p)
    {
        // Called if interrupted (e.g. hit by enemy)
        timer = 0f;
    }

    public void Update(PlayerController p)
    {
        if (p.groundCheck != null && p.groundCheck.IsGrounded())
            wasGrounded = true;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (wasGrounded)
            {
                p.SetState(new IdleState());
            }
            else
            {
                p.SetState(new AirIdleState());
            }
        }
    }

    string WhatAttack()
    {
        // Attack Priority : Vertical, then horizontal (Up and right will give an up input)
        return attack switch
        {
            (> 0, > 0) => "Up",   // Up-Right 
            (< 0, > 0) => "Up",   // Up-Left 
            (> 0, < 0) => "Down",   // Down-Right 
            (< 0, < 0) => "Down",   // Down-Left 
            (0, > 0)  => "Up",    // Up 
            (0, < 0)  => "Down",    // Down 
            (> 0, 0)  => "Right",    // Right 
            (< 0, 0)  => "Left",    // Left 
            (0, 0)    => "Neutral",    // Neutral 
            _         => "Unknown"
        };
    }

    public void HandleInput(PlayerController p)
    {
        //Ignore input during attacks
    }

    public override string ToString()
    {
        return $"AttackState({attackType})";
    }
}
