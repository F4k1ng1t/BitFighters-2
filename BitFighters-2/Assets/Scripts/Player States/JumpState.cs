using UnityEngine;

public class JumpState : IPlayerState
{
    // small delay so the state change happens after Enter returns (avoids nested SetState timing issues)
    private const float TransitionDelay = 0.05f;
    private float _timer;

    public void Enter(PlayerController p)
    {
        Debug.Log("Enter JumpState: applying jump force");

        p.rig.AddForce(new Vector2(0, p.jumpForce), ForceMode2D.Impulse);
        _timer = TransitionDelay;
    }

    public void Exit(PlayerController p)
    {
    }

    public void ForceExit(PlayerController p)
    {
        // immediate cancel if needed
        _timer = 0f;
    }

    public void Update(PlayerController p)
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            
            p.SetState(new AirIdleState());
        }
    }

    public void HandleInput(PlayerController p)
    {
    }

    public override string ToString()
    {
        return "JumpState";
    }
}