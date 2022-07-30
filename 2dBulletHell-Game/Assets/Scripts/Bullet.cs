using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform tr;
    private SpriteRenderer Gun;
    private bool shooted = false;
    public float speed;
    public float destroyTime;
    public float damage = 5f;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        speed /= 10f;
        tr = GetComponent<Transform>();
        Gun = GameObject.Find("Gun").GetComponent<SpriteRenderer>();

        if (Gun.flipX == true && !shooted)
        {
            speed *= -1;
        }

        shooted = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        tr.Translate(new Vector3(speed, 0f));
        
        Destroy(gameObject, destroyTime);
     
    }
}
