using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Step : MonoBehaviour
{
    public GameObject Steps;
    private GameObject Player;
    public GameObject ShatteredStep;
    private Transform Shatter;
    Tween myTween;
    private bool follow = true;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Steps.transform.position = new Vector3(Player.transform.position.x, Steps.transform.position.y, 0);
        Set_Color(Steps);
    }
    private void OnTriggerEnter(Collider other)
    {
        follow = false;
        Shatter = Steps.transform;
        Rigidbody Rb = ShatteredStep.GetComponent<Rigidbody>();
        Instantiate(ShatteredStep, Shatter.position, Shatter.rotation); 
        Rb.AddExplosionForce(4000, ShatteredStep.transform.position, 200);
        Destroy(Steps);
        GameObject[] shatters = GameObject.FindGameObjectsWithTag("Shatter");
        foreach (GameObject shatter in shatters)
        GameObject.Destroy(shatter, 0.8f);
    }
    void Update()
    {
        Steps.transform.eulerAngles = new Vector3(0, 0, 0);
        if(follow == true)
            Steps.transform.position = new Vector3(Player.transform.position.x, Steps.transform.position.y, 0);
        else
            Steps.transform.position = new Vector3(Steps.transform.position.x, Steps.transform.position.y, 0);
        Steps.transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
    }
    private int switcher_old = 0;
    private int switcher_new = 7;
    void Set_Color(GameObject gameObject)
    {
        //generator part
        switcher_new = Random.Range(1, 6);
        switch (switcher_new)
        {
            case 1:
                var Red = gameObject.GetComponent<Renderer>();
                Red.material.SetColor("_Color", Color.red);
                break;
            case 2:
                var Blue = gameObject.GetComponent<Renderer>();
                Blue.material.SetColor("_Color", Color.blue);
                break;
            case 3:
                var Yellow = gameObject.GetComponent<Renderer>();
                Yellow.material.SetColor("_Color", Color.yellow);
                break;
            case 4:
                var Green = gameObject.GetComponent<Renderer>();
                Green.material.SetColor("_Color", Color.green);
                break;
            case 5:
                var Purple = gameObject.GetComponent<Renderer>();
                Purple.material.SetColor("_Color", Color.magenta);
                break;
            case 6:
                var White = gameObject.GetComponent<Renderer>();
                White.material.SetColor("_Color", Color.white);
                break;
        }
        switcher_old = switcher_new;
    }
    IEnumerator Explosion(Rigidbody Xplosion)
    {
        yield return new WaitForSeconds(1);
        Rigidbody Rb = ShatteredStep.GetComponent<Rigidbody>();
        Instantiate(ShatteredStep, ShatteredStep.transform.position, ShatteredStep.transform.rotation);
        Rb.AddExplosionForce(4000, ShatteredStep.transform.position, 2000);
        Destroy(ShatteredStep, 0.2f);

    }
    
}
