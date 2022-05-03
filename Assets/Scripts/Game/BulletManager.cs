using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private int speed = 20;
   
    private void Update()
    {
        BulletFire();
    }
    public void BulletFire()
    {
        this.gameObject.transform.Translate(transform.up *speed * Time.deltaTime,0);
    }
}
