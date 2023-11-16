using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject Player;
    public float distanceFromPlayer = 10;
    public float height = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Player.transform.position - Player.transform.forward * distanceFromPlayer;
       transform.LookAt(Player.transform.position); 
       transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z );
    }
}
