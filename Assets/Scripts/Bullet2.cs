using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet2 : MonoBehaviour
{

    public float speed = 2.0f;
    //public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        //enemy.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime, Space.Self);
        //transform.Translate(speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            print("ignoring you");
        }
        else
        {
            print("I hit " + other.gameObject.name);
            GameObject.Destroy(gameObject);
        }
        if (other.tag == "enemy")
        {
            
            Destroy(other.gameObject);
            // change the UI score.
            GameObject ui_game_obj = GameObject.Find("main_ui");
            main_ui ui_script_obj = ui_game_obj.GetComponent<main_ui>();
            ui_script_obj.change_ui_score(50);
            ui_script_obj.scoreValue += 10;
        }

        if (other.tag == "spawner")
        {
            Destroy(other.gameObject);
            // change the UI score.
            GameObject ui_game_obj = GameObject.Find("main_ui");
            main_ui ui_script_obj = ui_game_obj.GetComponent<main_ui>();
            ui_script_obj.change_ui_score(50);
            ui_script_obj.scoreValue += 10;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
