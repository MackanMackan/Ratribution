using UnityEngine;

public delegate void onHitPlayer();
public delegate void onDeadPlayer();
public class CharacterHealth : MonoBehaviour
{
    public static event onHitPlayer onHitPlayer;
    public static event onDeadPlayer onDeadPlayer;
    [SerializeField]public static int health = 500;
    static bool isDead = false;
    public static void DamageMe(int damage)
    {
        health -= damage;
        onHitPlayer?.Invoke();
        if(health <= 0 && !isDead)
        {
            isDead = true;
            onDeadPlayer?.Invoke();
        }
    }

    public static int GetHealth()
    {
        return health;
    }
}
