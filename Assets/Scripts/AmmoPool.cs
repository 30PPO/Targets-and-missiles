using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPool : MonoBehaviour
{
    public static AmmoPool instance;

    [SerializeField]
    private float bulletSpeed = 5f;


    [Header("Pool configuration")]
    [SerializeField]
    private int poolCount = 3;
    [SerializeField]
    private bool autoExpand = false;
    [SerializeField]
    private Bullet ammoPref;

    

    [SerializeField]
    private Transform weapon;

    private PoolObjects<Bullet> pool;
    int numberTarget = 1;

    private void Start()
    {
        instance = this;
        pool = new PoolObjects<Bullet>(ammoPref, poolCount, transform);
        pool.autoExpand = autoExpand;
    }

    public void CreateBullet() 
    {
        var bullet = pool.GetFreeElement();
        bullet.transform.position = weapon.position;
        bullet.target = GameObject.Find($"Target {numberTarget}").transform;
        bullet.speed = bulletSpeed;
        
        if (numberTarget >= 3)
            numberTarget = 1;
        else
            numberTarget++;
    }












}
