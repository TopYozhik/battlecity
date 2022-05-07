using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    GameObject bulletBall, fire;
    Bullet bulet;
    [SerializeField]
    int speed;
    void Start () {
        bulletBall = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        bulet = bulletBall.GetComponent<Bullet>();
        bulet.speed = speed;
        fire = transform.GetChild(0).gameObject;
    }
    public void Fire()
    {
        if (bulletBall.activeSelf == false)
        {
            bulletBall.transform.position = transform.position;
            bulletBall.transform.rotation = transform.rotation;
            StartCoroutine(ShowFire());
            bulletBall.SetActive(true);
        }   
    }
    IEnumerator ShowFire()
    {
    	fire.SetActive(true);
    	yield return new WaitForSeconds(0.25f);
    	fire.SetActive(false);
    }
    private void OnDestroy()
    {
        if (bulletBall != null) bulet.DestroyBullet();
    }
}
