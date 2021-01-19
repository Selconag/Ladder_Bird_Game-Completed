using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
public class LevelManage : MonoBehaviour
{
    private GameObject Player;
    public GameObject Ladder1;
    public GameObject Ladder2;
    public GameObject Ladder3;
    public GameObject Ladder4;
    public GameObject Ladder5;
    public GameObject Zemin;
    public float Current_Y=-1.0f;
    public float Current_X = 8.0f;
    public float Boundaries_X = 60.0f;
    public float Boundaries_Y = 5f;
    public float Boundaries_NY = -5f;
    public bool call = true;
    private int switcher_Terrain = 0;
    private int switcher_Level = 7;
    public float destroy_time = 14.0f;
    public Vector3 Spawn;
    
    private Vector3 newSpawn;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Spawn.z = 0;
        Spawn.x = 12.0f;
        Spawn.y = 0;
    }
    void Update()
    {
        if (call == true)
        {
            StartCoroutine(Wait());
        }
        if (Current_X <= Boundaries_X)
            Zemin_Randomizer();
        Randomizer();
    }
    IEnumerator Wait()
    {
        call = false;
        Randomizer();
        yield return new WaitForSeconds(3);
        call = true;
    }

    void Randomizer()
    {
        newSpawn.x = newSpawn.x + 12.0f;
        newSpawn.y = 1.5f + Current_Y;
        //generator part
        switcher_Level = Random.Range(1, 6);
        /*generator but with less random coefficient
        if (switcher_old > 3)
        {
            switcher_new = Random.Range(1, 3);
        }
        else if (switcher_old < 3)
        {
            switcher_new = Random.Range(3, 6);
        }
        else
        {
            switcher_new = Random.Range(1, 6);
        }*/
        switch (switcher_Level)
        {
            case 1:
                GameObject Ladderx = Instantiate(Ladder1, newSpawn, Player.transform.rotation);
                Destroy(Ladderx, destroy_time);
                break;
            case 2:
                GameObject Laddery = Instantiate(Ladder2, newSpawn, Player.transform.rotation);
                Destroy(Laddery, destroy_time);
                break;
            case 3:
                GameObject Ladderz = Instantiate(Ladder3, newSpawn, Player.transform.rotation);
                Destroy(Ladderz, destroy_time);
                break;
            case 4:
                newSpawn.y += 0.5f;
                GameObject Ladderc = Instantiate(Ladder4, newSpawn, Player.transform.rotation);
                Destroy(Ladderc, destroy_time);
                break;
            case 5:
                GameObject Ladderv = Instantiate(Ladder5, newSpawn, Player.transform.rotation);
                Destroy(Ladderv, destroy_time);
                break;
            case 6:
                GameObject Ladderw = Instantiate(Ladder3, newSpawn, Player.transform.rotation);
                Destroy(Ladderw, destroy_time);
                break;
        }
    }

    void Zemin_Randomizer()
    {
        //Current_Y kullanarak tasarla
        
        
        Spawn.x = Current_X;
        switcher_Terrain = Random.Range(1, 3);
        if (Current_Y == Boundaries_Y)
            switcher_Terrain = 2;
        else if (Current_Y == Boundaries_NY)
            switcher_Terrain = 1;
        switch (switcher_Terrain)
        {
            case 1:
                Current_Y++;
                Spawn.y = Current_Y;
                GameObject Zeminx = Instantiate(Zemin, Spawn, Player.transform.rotation);
                Destroy(Zeminx, destroy_time);
                break;
            case 2:
                Current_Y--;
                Spawn.y = Current_Y;
                GameObject Zeminy = Instantiate(Zemin, Spawn, Player.transform.rotation);
                Destroy(Zeminy, destroy_time);
                break;
        }
        Current_X = Current_X + 8.0f;
    }

}
