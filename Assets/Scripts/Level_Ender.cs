using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Ender : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Manager.instance.GameWin();
    }
}
