using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{

    public float speed = 2.0f;

    Vector2 move_vector;
    Rigidbody my_rigid_body;
    public GameObject bullet_prefab;
    bool aim_needs_adjusted = false;
    Ray aim_ray;
    Camera my_camera;
    Transform mesh_transform;
    Transform aim_transform;
    public AudioSource audioClip;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello x");

        my_rigid_body = GetComponent<Rigidbody>();      // Do some error checking here??

        my_camera = transform.Find("Main_Camera").gameObject.GetComponent<Camera>();
        mesh_transform = transform.Find("Player_mesh");
        aim_transform = mesh_transform.Find("aimer");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 velocity = (new Vector3(move_vector.x, 0, move_vector.y)).normalized * speed;
        //transform.Translate(velocity * Time.deltaTime, Space.World);
        //print(velocity);
    }

    // Best to do any Physics-related updates here rather than Update.
    private void FixedUpdate()
    {
        Vector3 velocity = (new Vector3(move_vector.x, 0, move_vector.y)).normalized * speed;
        //transform.Translate(velocity * Time.deltaTime, Space.World);

        my_rigid_body.velocity = velocity;      // No need for delta time (its handled internally) if we ever need it though it is Time.fixedDeltaTime

        // Do the raycast to aim us, if necessary
        if (aim_needs_adjusted)
        {
            aim_needs_adjusted = false;

            // Do the raycast
            RaycastHit hit_result;
            if (Physics.Raycast(aim_ray, out hit_result, Mathf.Infinity, 1 << 8))
            {
                // We hit something (the ground)
                //print("raycast hit: " + hit_result.point);
                Vector3 look_at_pt = new Vector3(hit_result.point.x, mesh_transform.position.y, hit_result.point.z);

                mesh_transform.LookAt(look_at_pt, Vector3.up);
            }
        }
    }

    

    public void fire(InputAction.CallbackContext context)
    {
        float button = context.ReadValue<float>();
        if (button > 0.5f && context.performed)
        {
            // Play the sound
            audioClip.Play();

            // Spawn a bullet
            print("fire function: " + button);

            GameObject new_inst = GameObject.Instantiate(bullet_prefab);
            new_inst.transform.position = aim_transform.position;
            new_inst.transform.rotation = aim_transform.rotation;

            //This might be necessary to get your bullet to truly face int the dircetion I am facing
            //new_inst.transform.Rotate(Vector3.up, 90)
        }
    }

    public void move(InputAction.CallbackContext context)
    {
        move_vector = context.ReadValue<Vector2>();
        print("move function: " + move_vector);
    }

    public void look_at(InputAction.CallbackContext context)
    {
        PlayerInput input_comp = GetComponent<PlayerInput>();

        if (input_comp.currentControlScheme == "Keyboard&Mouse")
        {
            Vector2 look_vector = context.ReadValue<Vector2>();
            //print("look = " + look_vector + " control = " + input_comp.currentControlScheme);

            Vector2 mouse_pos = Input.mousePosition;

            // Save away some info to be used later (in Fixed Update) to do the actual raycast

            aim_needs_adjusted = true;
            aim_ray = my_camera.ScreenPointToRay(mouse_pos);
        }
    }
}