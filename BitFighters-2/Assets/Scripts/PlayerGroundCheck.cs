using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    [Header("Ground Check Settings")]
    public Transform checkPoint;      // Child object at the player's feet
    public LayerMask groundLayer;     // Layer of ground objects
    public float rayLength = 0.1f;    // How far down to check

    // Optional: debug visuals
    private void OnDrawGizmos()
    {
        if (checkPoint == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(checkPoint.position, checkPoint.position + Vector3.down * rayLength);
    }

    // Call this to check if grounded
    public bool IsGrounded()
    {
        if (checkPoint == null) return false;

        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, Vector2.down, rayLength, groundLayer);
        return hit.collider != null;
    }
}
