using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float angularSpeed;

    [SerializeField]
    private Transform center;
    [SerializeField]
    private float radius = 4f;

    float posX, posY;
    float angle = 0f;

    private void Start()
    {
        center = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        posX = center.position.x + Mathf.Cos(angle) * radius;
        posY = center.position.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector2 (posX, posY);


        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
            angle = 0f;
    }
}
