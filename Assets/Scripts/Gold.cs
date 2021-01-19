using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gold : MonoBehaviour
{
    private bool used=false;
    private void OnTriggerEnter(Collider other)
    {
        if (!used) {
        used = true;
        Destroy(this.gameObject);
        Debug.Log("Managed");
        Manager.instance.Collect_Gold();
        }
    }
}
