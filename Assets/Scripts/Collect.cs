using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

    public int points;
    public AudioClip coinSound;

	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Object.Destroy(gameObject);
        GameManager.AddScore(points);
        AudioSource.PlayClipAtPoint(coinSound, transform.position, 1.0f);
        
    }
}
