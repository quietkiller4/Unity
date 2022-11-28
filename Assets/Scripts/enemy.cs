using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public Material normal_mat;
    public Material angry_mat;

    //public GameObject player;

    Transform player;
    public float speed = 0.5f;
    private float dist;
    public float howClose;


    // Temp (swap material after a few seconds)
    //float time_to_mat_swap = 3.0f;
    bool needs_swap = false;
    //float moveSpeed = 3.0f;
    //float dirX = -1f;
    //public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player2");
        player = GameObject.FindGameObjectWithTag("player").transform;
        //Transform transform1 = GameObject.FindGameObjectsWithTag("player").;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        //Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        //transform.position += transform.forward * speed * Time.deltaTime;

        dist = Vector3.Distance(player.position, transform.position);
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

        if (dist <= howClose)
        {
            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.material = angry_mat;
            print("changing materials");
            needs_swap = true;
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
        else
        {
            needs_swap = false;
            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.material = normal_mat;
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
        }

        
        /*if (lookPos <= Vector3(5, 0, 0))
        { 
            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.material = angry_mat;
            print("changing materials");
            needs_swap = true;
        }
        else
        {

            needs_swap = false;
        }*/
    }
}
