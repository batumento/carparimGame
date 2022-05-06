using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bulletClip;

    private int rotateSpeed = 10;
    private float fireDuraction = 200;
    private float fireTime = 0;
    private float angle;
    public bool rotateChange = false;


    private void Start()
    {
        rotateChange = true;
    }

    void Update()
    {
        if (!rotateChange)
        {
            RotateChange();
        }
    }

    void RotateChange()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        if (angle<45 && angle>-45)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
       
        if (Input.GetMouseButtonDown(0))
        {
            

            if (Time.time>fireTime)
            {
                fireTime = Time.time + fireDuraction / 1000;
                FireActive();
            }
        }
       
    }

    private void FireActive()
    {
        audioSource.PlayOneShot(bulletClip);
        GameObject bullet = Instantiate(bullets[Random.Range(0, bullets.Length)],bulletTransform.position, bulletTransform.rotation) as GameObject;
    }
}
