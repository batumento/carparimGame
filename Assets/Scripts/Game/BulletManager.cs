using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private int speed = 20;
    private void Start()
    {
        if(this.gameObject != null)
        {
            Destroy(gameObject,1f);
        }
    }
    private void Update()
    {
        BulletFire();
    }
    public void BulletFire()
    {
        this.gameObject.transform.Translate(transform.up *speed * Time.deltaTime,0);
    }
}
