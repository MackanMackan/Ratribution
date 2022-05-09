using UnityEngine;

public class CreateSpear : MonoBehaviour
{
    [SerializeField] GameObject spearThrown;
    [SerializeField] GameObject spear;
    public void ShootSpear()
    {
        GameObject insSpear = Instantiate(spearThrown, spear.transform.position,Quaternion.identity);
    }
}
