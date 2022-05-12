using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTarget : MonoBehaviour
{
    [SerializeField]
    private float ShootCooldown;
    //[SerializeField]
    //private GameObject bullet;

    private List<GameObject> Bullets;

    private float ShootCooldownRemaining;

    void Start()
    {
        ShootCooldownRemaining = ShootCooldown;
    }

    void Update()
    {
        UIShow.instance.ChangeReload(Mathf.Round(ShootCooldownRemaining).ToString());
        if (ShootCooldownRemaining <= 0)
        {
            if (Input.GetKeyDown("space") || Input.GetKeyDown("tab"))
            {
                AmmoPool.instance.CreateBullet();
                ShootCooldownRemaining = ShootCooldown;
            }    
        }
        else
            ShootCooldownRemaining -= Time.deltaTime;
    }
}
