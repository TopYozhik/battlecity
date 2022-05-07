using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    public int speed = 1;
    Rigidbody2D rb2d;
    GameObject brickGameObject;
    Tilemap tilemap;
    [SerializeField] bool toBeDestroyed = false;
    //[SerializeField] GameObject Player;

    void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
        //rb2d.transform.rotation = Player.transform.rotation;
        brickGameObject = GameObject.FindGameObjectWithTag("Brick");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tilemap = collision.gameObject.GetComponent<Tilemap>();
        rb2d.velocity = Vector2.zero;
        if (collision.gameObject.GetComponent<EnemyHP>() != null)
        {
            collision.gameObject.GetComponent<EnemyHP>().TakeDamage();
        }
        if (collision.gameObject == brickGameObject) {
            if (collision.gameObject == brickGameObject)
            {
                Vector3 hitPosition = Vector3.zero;
                foreach (ContactPoint2D hit in collision.contacts)
                {
                    hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                    hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
                }
            }
        }
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (rb2d != null)
        {
            rb2d.velocity = transform.up * speed;
            //rb2d.transform.rotation = Player.transform.rotation;
        }
    }
    private void OnDisable()
    {
        if (toBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }
    public void DestroyBullet()
    {
        if (gameObject.activeSelf == false)
        {
            Destroy(this.gameObject);
        }
        toBeDestroyed = true;
    }
}
