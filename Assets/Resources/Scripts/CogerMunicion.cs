using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerMunicion : MonoBehaviour
{
    public GameObject laCajita;
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponManager.Instance.totalRifleAmmo += 170;
            WeaponManager.Instance.totalPistolAmmo += 300;
            laCajita.SetActive(false); /*NO usar Destroy()*/
        }
    }
}
