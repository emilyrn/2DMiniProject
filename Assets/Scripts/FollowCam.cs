using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float maxSpeed;
    public Vector2 topLeft;
    public Vector2 bottomRight;
    public float maxShake = 1.0f;
    public GameObject background;
    public float bgScrollPercent = .2f;
    public GameObject middlebackground;
    public float mbgScrollPercent = .5f;
    public GameObject foreground;
    public float fgScrollPercent = 1.3f;

    private GameObject target;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player");

        Vector3 newPos = target.transform.position;
        newPos.z = transform.position.z;
        transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 oldPos = transform.position;

        if (target == null)
        {
            Shake();
        }
        else
        {
            Vector2 newPos = Vector2.MoveTowards(
                                transform.position,
                                target.transform.position,
                                maxSpeed * Time.deltaTime
                            );

            //how do we limit the camera between topLeft & bottomRight?
            newPos.x = Mathf.Clamp(newPos.x, topLeft.x, bottomRight.x);
            newPos.y = Mathf.Clamp(newPos.y, bottomRight.y, topLeft.y);
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }

        Vector3 offset = (Vector2)transform.position - oldPos;
        background.transform.Translate(offset * (bgScrollPercent));
        if (middlebackground != null)
        {
            middlebackground.transform.Translate(offset * (mbgScrollPercent));
        }
        if (foreground != null)
        {
            foreground.transform.Translate(-1 * offset * (fgScrollPercent));
        }
    }

    public void Shake()
    {
        transform.position += new Vector3(
            Random.Range(-maxShake, maxShake),
            Random.Range(-maxShake, maxShake),
            0
        );
    }
}