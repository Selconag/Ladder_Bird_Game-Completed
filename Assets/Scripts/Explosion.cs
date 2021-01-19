using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Explosion : MonoBehaviour
{
    public GameObject ShatteredStep;
    float timer = 1.0f;
    float  createTime = 0.0f;
    void Start()
    {
        createTime = Time.time;
    }
    void Update()
    {
        if ((Time.time - createTime) > timer)
        {
            Rigidbody Rb = ShatteredStep.GetComponent<Rigidbody>();
            Instantiate(ShatteredStep, ShatteredStep.transform.position, ShatteredStep.transform.rotation);
            Rb.AddExplosionForce(4000, ShatteredStep.transform.position, 2000);
            Destroy(ShatteredStep, 0.2f);
        }
    }
   
}
