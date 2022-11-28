using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{

    Animator animator_comp;
    bool is_walking = false;        // not directly connected but we'll make it so any time this changes we also
                                    // change the bool in the animation controller
    float time_to_change = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator_comp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time_to_change -= Time.deltaTime;
        if (time_to_change < 0.0f)
        {
            time_to_change = 2.0f;
            is_walking = !is_walking;

            // Make the bool in the animator controller match our code boolen
            animator_comp.SetBool("is_walking", is_walking);
        }
    }
}
