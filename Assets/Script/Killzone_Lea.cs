using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone_Lea : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(collision.gameObject);
    }
}
