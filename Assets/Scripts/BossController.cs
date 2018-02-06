using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public EditorPathScript PathToFollow;

    public int CurrentWayPointID = 0;
    public float speed;

    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;

    Vector3 last_position;
    Vector3 current_position;
    void Start()
    {
        //PathToFollow = GameObject.Find(pathName).GetComponent<EditorPathScript>();
        last_position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);

        if(distance <= reachDistance)
        {
            CurrentWayPointID++;
        }
    }

 
}
