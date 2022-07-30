using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float healt = 100f;
    private TextMeshPro healtText;
    private ParticleSystem particleSys;
    // Start is called before the first frame update
    void Start()
    {
        healtText = gameObject.GetComponentInChildren<TextMeshPro>();
        healtText.text = healt.ToString();

        //Particle System
        particleSys = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet Enter TRIGGER");
            Bullet b = collision.GetComponent<Bullet>();
            
            //Particle System
            Quaternion rotation = Quaternion.Euler(0f, 90f, -90f);
            if (collision.transform.position.x - transform.position.x < 0)
            {
                
                particleSys.transform.rotation = rotation;
            }
            else
            {
                rotation = Quaternion.Euler(180f, 90f, -90f);
                particleSys.transform.rotation = rotation;
            }

            particleSys.Play();


            Destroy(collision.gameObject);


            //healt enemy
            healt -= b.damage;
            healtText.text = healt.ToString();
            if (healt <= 0f)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
