using UnityEngine;

public delegate void onHitPlayer();
public class CharacterHealth : MonoBehaviour
{
    public static event onHitPlayer onHitPlayer;
    [SerializeField] static int health = 500;
    public static void DamageMe(int damage)
    {
        health -= damage;
        onHitPlayer?.Invoke();
    }

    public static int GetHealth()
    {
        return health;
    }
}
