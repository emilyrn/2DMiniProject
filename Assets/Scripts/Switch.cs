using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    private bool switchOn = false;
    public int flip = -1; //-1 means the sprite faces right
    public AudioClip switchSound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        AudioSource.PlayClipAtPoint(switchSound, transform.position, 1.0f);
        Vector3 scale = transform.localScale;
        scale.x = -1 * flip;
        transform.localScale = scale;
        
    }



}



