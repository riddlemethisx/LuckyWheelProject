using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CursorTrigger : MonoBehaviour
{

    public LuckyWheel spinner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Areas"))
            spinner.SetPrizeIndex(int.Parse(other.gameObject.name));
    }
}
