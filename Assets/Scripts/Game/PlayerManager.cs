using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private GameObject[] bullets;


    private int rotateSpeed = 10;
    private float fireDuraction = 200;
    private float fireTime = 0;
    private float angle;

    void Update()
    {
        RotateChange();
    }

    void RotateChange()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

            if (Time.time>fireTime)
            {
                fireTime = Time.time + fireDuraction / 1000;
                FireActive();
            }
        }
        
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }

    private void FireActive()
    {
       GameObject bullet= Instantiate(bullets[Random.RandomRange(0, bullets.Length)],bulletTransform.position, bulletTransform.rotation) as GameObject;
    }
}
