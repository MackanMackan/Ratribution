using UnityEngine;

public delegate void onHitPlayer();
public delegate void onDeadPlayer();
public class CharacterHealth : MonoBehaviour
{
    public event onHitPlayer onHitPlayer;
    public event onDeadPlayer onDeadPlayer;
    [SerializeField]public int health = 500;
    bool isDead = false;
    public void DamageMe(int damage)
    {
        health -= damage;
        onHitPlayer?.Invoke();
        if(health <= 0 && !isDead)
        {
            isDead = true;
            onDeadPlayer?.Invoke();
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
