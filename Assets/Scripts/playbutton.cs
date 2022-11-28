using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton : MonoBehaviour
{

    public AudioSource audioClip;
    public static playbutton instince;

    // Start is called before the first frame update
    public void PlayGame()
    {
        DontDestroyOnLoad(this.gameObject);
        audioClip.Play();
        print("play game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (instince == null)
        {
            instince = this;
        }    
        else
        {
            Destroy(gameObject);
        }
    }
}
