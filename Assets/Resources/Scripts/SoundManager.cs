using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance{get; set;}
    public AudioSource ShootingRifle;
    public AudioSource ReloadRifle;

    public AudioSource ShootingPistol;
    public AudioSource ReloadPistol;
    public AudioSource EmptyPistol;


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

    /*public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel Pistol:
            ShootingPistol.PlayOneShot();
            break;

            case WeaponModel Rifle:
            ShootingRifle.PlayOneShot();
            break;
        }
    }

    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel Pistol:
            ReloadPistol.Play();
            break;

            case WeaponModel Rifle:
            ReloadRifle.Play();
            break;
        }
    }*/
}
