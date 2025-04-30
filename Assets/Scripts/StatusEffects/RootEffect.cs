using System.Collections;
using UnityEngine;

public class RootEffect : MonoBehaviour, ISStatusEffect
{
    private Enemy enemy;

    public void Apply(GameObject target, float duration)
    {
        enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            StartCoroutine(ApplyRoot(duration));
        }
    }

    private IEnumerator ApplyRoot(float duration)
    {
        enemy.SetRooted(true);
        yield return new WaitForSeconds(duration);
        enemy.SetRooted(false);
        Destroy(this); // Efekt bitince kendini yok et
    }
}
