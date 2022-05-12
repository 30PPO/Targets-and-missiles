using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnEnable()
    {
        transform.position = startPos;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(transform.position == target.position)
            this.gameObject.SetActive(false);
    }
}
