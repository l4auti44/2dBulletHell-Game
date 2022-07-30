using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float angularSpeed = 1f;
    public float circleRad = 1f;

    public float timeForSpawn = 5f;

    private float time = 0f;
    private Vector2 fixedPoint;
    private float currentAngle;


    public GameObject[] mobs;
    // Start is called before the first frame update
    void Start()
    {
        fixedPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //movement
        currentAngle += angularSpeed * Time.deltaTime;
        Vector2 offset = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * circleRad;
        transform.position = fixedPoint + offset;

        //Spawn
        time += Time.deltaTime;
        //spawn
        if (time >= timeForSpawn)
        {
            time = 0f;
            Debug.Log("Spawn");
            foreach (GameObject mob in mobs)
            {
                Instantiate(mob, transform.position, transform.rotation);
            }
        }

    }
}
