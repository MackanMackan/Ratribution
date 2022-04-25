using UnityEngine;

public interface IDestructable
{
    void DamageMe(int damage, GameObject recievedFrom, int impactJumpAt);
    void ActivatePhysics();
    void AddForceInDirection(Vector3 direction, float forceMagnitude);
    void CheckIfDead();
    void GetHitDirection(Vector3 direction);
}