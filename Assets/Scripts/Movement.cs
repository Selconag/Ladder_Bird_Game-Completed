using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Players;
    public GameObject Stepp;
    private Transform place;
    public int forceConst = 1;
    private bool canJump;
    public float speed=5.0f;
    private Rigidbody selfRigidbody;
    private Vector3 spawner; 
    void Start()
    {
        DOTween.Init();
        place = Players.transform;
        selfRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Players.transform.eulerAngles = new Vector3(0,0,0);
        Players.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        Players.transform.position = new Vector3(Players.transform.position.x, Players.transform.position.y, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Manager.instance.thegame == true)
            {
                spawner = new Vector3(Players.transform.position.x, Players.transform.position.y + 1.0f, Players.transform.position.z);
                //Players.transform.position = spawner;
                Players.transform.DOMove(spawner, 0.15f).SetEase(Ease.InOutQuad).OnComplete(() => Stepps(spawner));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Manager.instance.thegame == true)
                selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
        }
    }
    public void Stepps(Vector3 pos)
    {
        pos.y = pos.y - 1.0f;
        Instantiate(Stepp, pos, Players.transform.rotation);
    }

}
