using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class button : MonoBehaviour


{

    public void buttonmoment()
    {
        Debug.Log("Clicked on button");
        SceneManager.LoadScene("Samplescenex");
        //Samplescene = scene 2 switch

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
