using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    public AudioClip deathSound;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameManager.Death();
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 1.0f);
        }
        else
        {

            Object.Destroy(col.gameObject);
        }
    }

}
