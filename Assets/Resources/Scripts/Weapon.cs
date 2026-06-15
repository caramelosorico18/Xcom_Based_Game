using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    public bool isShooting, readyToShoot;
    private bool allowReset = true;
    public float shootingDelay = 2f;
    public int bulletsPerBurst;
    public int burstBulletsLeft;
    public float spreadIntendity;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 3f;

    public GameObject muzzleEffect;
    private Animator animator;

    public float reloadTime;
    public int magazineSize, bulletsLeft;
    public bool isReloading;

    public enum WeaponModel
    {
        Pistol,
        Rifle
    }

    public WeaponModel thisWeaponModel;

    public enum shootingMode
    {
        Single, Burst, Auto
    }
    public shootingMode currentShootingMode;

    void Awake()
    {
        readyToShoot = true;
        burstBulletsLeft = bulletsPerBurst;
        animator = GetComponent<Animator>();
        bulletsLeft = magazineSize;
    }
    void Update()
    {
        if(bulletsLeft == 0 && isShooting)
        {
            SoundManager.Instance.EmptyPistol.Play();
        }
        if(currentShootingMode == shootingMode.Auto)
        {
            isShooting = Input.GetKey(KeyCode.Mouse0); //hold button only
        }
        else if(currentShootingMode == shootingMode.Burst || currentShootingMode == shootingMode.Single)
        {
            isShooting = Input.GetKeyDown(KeyCode.Mouse0); //Just once per click
        }
        if(readyToShoot && isShooting && bulletsLeft > 0)
        {
            burstBulletsLeft = bulletsPerBurst;
            FireWeapon();
        }
        if(AmmoManager.Instance.ammoDisplay != null)
        {
            AmmoManager.Instance.ammoDisplay.text = $"{bulletsLeft/bulletsPerBurst}/{magazineSize/bulletsPerBurst}";
        }
        //Se divide por buleltsPerBurst por si hay armas que disparen mas de una bala a la vez, AKA Escopetas
        //!!!Poner BulletsPerBusrts siempre a 1, no queremos dividir por cero
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && isReloading == false && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            Reload();
        }
        if(readyToShoot && isShooting == false && isReloading == false && bulletsLeft <= 0 && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            Reload();
        }
    }

    private void FireWeapon()
    {
        bulletsLeft--;
        muzzleEffect.GetComponent<ParticleSystem>().Play();
        animator.SetTrigger("Recoil");

        //SoundManager.Instance.ShootingPistol.Play();
        SoundManager.Instance.PlayShootingSound(thisWeaponModel);

        readyToShoot = false;
        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.transform.forward = shootingDirection;
        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity, ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));
        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }
        if(currentShootingMode == shootingMode.Burst && burstBulletsLeft > 1)
        {
            burstBulletsLeft--;
            Invoke("FireWeapon", shootingDelay);
        }
    }
    private void Reload()
    {
        readyToShoot = false;

        //SoundManager.Instance.ReloadPistol.Play();
        SoundManager.Instance.PlayReloadSound(thisWeaponModel);

        animator.SetTrigger("Reload");
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
        readyToShoot = true;
    }
    private void ReloadCompleted()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
    }

    public Vector3 CalculateDirectionAndSpread()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }
        Vector3 direction = targetPoint - bulletSpawn.position;
        float x = UnityEngine.Random.Range(-spreadIntendity, spreadIntendity);
        float y = UnityEngine.Random.Range(-spreadIntendity, spreadIntendity);

        return direction + new Vector3(x, y, 0);

    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float bulletPrefabLifeTime)
    {
        yield return new WaitForSeconds(bulletPrefabLifeTime);
        Debug.Log("Bullet destroyed after " + bulletPrefabLifeTime + " seconds");
        Destroy(bullet);
        
    }
}
