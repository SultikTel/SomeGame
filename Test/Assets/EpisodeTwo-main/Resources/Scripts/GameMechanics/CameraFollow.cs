using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform hero;
    [SerializeField] private Transform edgePointLeft;
    [SerializeField] private Transform edgePointRight;
    private float offset = 12f;

    void Update()
    {
        if (edgePointRight.position.x > hero.transform.position.x+ offset && hero.transform.position.x> edgePointLeft.position.x + offset)
        {
            transform.position = new Vector3(hero.position.x-2f, transform.position.y, transform.position.z);
        }
    }
}
