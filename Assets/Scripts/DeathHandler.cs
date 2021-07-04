using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    //AudioSource audi;

    // Start is called before the first frame update
    [SerializeField] Canvas GameOverCanvas;
   
    private void Start()
    {
        GameOverCanvas.enabled = false;
        //audi.GetComponent<AudioSource>();
    }

    public void HandleDeath()
    {
        //audi.Play();
        GameOverCanvas.enabled = true;
       // audi.Play();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
