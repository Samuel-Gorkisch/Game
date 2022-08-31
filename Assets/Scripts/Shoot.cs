using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Shoot : MonoBehaviour
{
    public Light2D muzzleFlash;
    public GameObject projectile;
    public float flashIntensity = 17f;
    private int fixedUpdateCount = 0;
    private bool muzzleFlashDisplayed = false;
    private GameObject barrelEnd;
    private GameObject aim;


    private void Awake()
    {
        barrelEnd = GameObject.Find("BarrelEnd");
        aim = GameObject.Find("Aim");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowMuzzleFlash();
            CreateProjectile();
            Instantiate(projectile, barrelEnd.transform.position, aim.transform.rotation);
        }
    }

    void FixedUpdate()
    {
        MaybeHideMuzzleFlash();
    }

    private void CreateProjectile()
    {
        
    }

    private void ShowMuzzleFlash()
    {
        muzzleFlashDisplayed = true;
        muzzleFlash.intensity = flashIntensity;
    }

    private void MaybeHideMuzzleFlash()
    {
        if (muzzleFlashDisplayed)
        {
            fixedUpdateCount += 1;
            if (fixedUpdateCount % 2 == 0)
            {
                muzzleFlashDisplayed = false;
                muzzleFlash.intensity = 0;
                fixedUpdateCount = 0;
            }
        }
        
    }
}
