using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    public float jumpForce = 400f;
    public int flip = -1; //-1 means the sprite faces right
    public AudioClip jumpSound;

    private Rigidbody2D rb;
    private Animator anim;
    private int moveHash;
    private Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveHash = Animator.StringToHash("Moving");
    }

    void Update()
    {
        if (GameManager.state != GameManager.GameState.playing)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal");

        if (Mathf.Abs(x) < .05)
        {
            anim.SetBool(moveHash, false);
        }
        else
        {
            anim.SetBool(moveHash, true);
        }

        rb.velocity = new Vector2(x * speed * Time.deltaTime, rb.velocity.y);
        if (x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1 * flip;
            transform.localScale = scale;
        }
        else if (x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = flip;
            transform.localScale = scale;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            rb.AddForce(new Vector2(0, jumpForce));
            AudioSource.PlayClipAtPoint(jumpSound, transform.position, 1.0f);
        }
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
    }

    private bool Grounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .6f,
            1 << LayerMask.NameToLayer("Midground"));

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}