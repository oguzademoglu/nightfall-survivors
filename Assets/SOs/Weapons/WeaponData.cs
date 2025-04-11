using UnityEngine;
public enum WeaponType { Melee, Ranged }

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Nightfall/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public WeaponType type;
    public float damage;
    public float attackRate;
    public float range;
    public float attackCooldown;

    public GameObject prefab; // Sword, projectile vs.
}
