using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float velocity = 1f;
    private Transform tr;
    private SpriteRenderer spriteRender;
    public GameObject gun;
    private SpriteRenderer gunSpRender;
    public Transform bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        gunSpRender = gun.GetComponent<SpriteRenderer>();
        tr = this.transform;
        spriteRender = this.GetComponent<SpriteRenderer>();

        velocity /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {tr.Translate(0, velocity, 0);}

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {tr.Translate(0, -velocity, 0);}

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
        {
            tr.Translate(-velocity, 0, 0);
            spriteRender.flipX = true;
            gunSpRender.flipX = true;
            if (bulletSpawn.localPosition.x > 0)
            {
                bulletSpawn.localPosition = new Vector3(-bulletSpawn.localPosition.x, bulletSpawn.localPosition.y, 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
        {
            tr.Translate(velocity, 0, 0);
            spriteRender.flipX = false;
            gunSpRender.flipX = false;
            if (bulletSpawn.localPosition.x < 0)
            {
                bulletSpawn.localPosition = new Vector3(bulletSpawn.localPosition.x * -1, bulletSpawn.localPosition.y, 0);
            }
        }

    }






}
