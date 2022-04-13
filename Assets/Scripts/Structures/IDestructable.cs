using UnityEngine;

public interface IDestructable
{
    void DamageMe(int damage, int hitID, GameObject recievedFrom, int impactJumpAt);
    void ActivatePhysics();
    void AddForceInDirection(Vector3 direction, float forceMagnitude);
    void CheckIfDead(int hitID, int impactJumpAt, int damage);
    void GetHitDirection(Vector3 direction);
}