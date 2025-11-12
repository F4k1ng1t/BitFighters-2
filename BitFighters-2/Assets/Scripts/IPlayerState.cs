using UnityEngine;

public interface IPlayerState
{
    void Enter(PlayerController player);
    void Exit(PlayerController player);
    void ForceExit(PlayerController player);
    void Update(PlayerController player);
    void HandleInput(PlayerController player);
    string ToString();

}
