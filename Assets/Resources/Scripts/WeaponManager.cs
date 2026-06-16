using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance{get; set;}
    public List<GameObject> weaponSlots;
    public GameObject activeWeaponSlot;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        activeWeaponSlot = weaponSlots[0];
    }

    private void Update()
    {
        foreach (GameObject weaponSlot in weaponSlots)
        {
            if(weaponSlot == activeWeaponSlot)
            {
                weaponSlot.SetActive(true);
            }
            else
            {
                weaponSlot.SetActive(false);
            }
        }
    }

    /*public void PickupWeapon(GameObject pickeupWeapon)
    {
        pickedupWeapon.transform.SetParent(activeWeaponSlot.transform, false);
        pickeupWeapon.transform.localPosition = new vector3(weaponSlots.spawnPosition.x, weaponSlots.spawnPosition.y, weaponSlots.spawnPosition.z);
        pickeupWeapon.transform.localRotation = Quaternion.Euler(weaponSlots.spawnRotation.x, weaponSlots.spawnRotation.y, weaponSlots.spawnRotation.z);
        weaponSlots isActiveWeapon = true;
    }*/
}
