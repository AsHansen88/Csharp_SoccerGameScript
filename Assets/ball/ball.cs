using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ball : MonoBehaviour
{

    private int Score = 0;
    private void OnTriggerEnter(Collider other){
        
        if( other.gameObject.tag == "Goal" ){
            Debug.Log("Goooal");
            Score++;
            Debug.Log("Score is: " + Score.ToString());
        
        }
    }
}
/*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
*/