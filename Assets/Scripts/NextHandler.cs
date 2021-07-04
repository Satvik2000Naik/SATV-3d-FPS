using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextHandler : MonoBehaviour
{
    [SerializeField] Canvas FinishCanvas;
    // Start is called before the first frame update
    void Start()
    {
        FinishCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   // [SerializeField] Canvas GameOverCanvas;
   /* private void Start()
    {
        GameOverCanvas.enabled = false;
    }*/

    public void HandleNext()
    {
        FinishCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
