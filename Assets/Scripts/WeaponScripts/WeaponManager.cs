using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform weaponHolder;
    public WeaponData startingWeapon;

    private GameObject currentWeaponGO;

    private void Start()
    {
        EquipWeapon(startingWeapon);
    }

    public void EquipWeapon(WeaponData weaponData)
    {
        if (currentWeaponGO != null)
            Destroy(currentWeaponGO);

        currentWeaponGO = Instantiate(weaponData.prefab, weaponHolder.position, Quaternion.identity, weaponHolder);

        WeaponBase weaponBase = currentWeaponGO.GetComponent<WeaponBase>();
        weaponBase.Initialize(weaponData); // Ayarları aktar
    }
}
