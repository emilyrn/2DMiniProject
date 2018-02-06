using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public AudioClip portalSound;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            GameManager.NextLevel();
            AudioSource.PlayClipAtPoint(portalSound, transform.position, 1.0f);
        }
    }
}
