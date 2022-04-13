using UnityEngine;

public interface IDestructable
{
    void DamageMe(int damage, int hitID, GameObject recievedFrom);
    void ActivatePhysics();
    void AddForceInDirection(Vector3 direction, float forceMagnitude);
    void CheckIfDead(int hitID);
    void GetHitDirection(Vector3 direction);
}