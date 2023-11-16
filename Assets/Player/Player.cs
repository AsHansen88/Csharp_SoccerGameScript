using System.Collections;

using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class Player : MonoBehaviour

{

    public float maxSpeed = 24f;

    public float timeToMax = .26f;

    private float GainPerSecond { get => maxSpeed / timeToMax; }

    public float jumpforce = 5.0f; 

    private Rigidbody playerRB;

    public bool isOnGround = true;

    public float timeToStop = .18f;

    private float LossPerSecond { get => maxSpeed / timeToStop; }

   
    public float reverseMomentum = 2.2f;

 

    public float rotationSpeed = .1f;

 

    private Vector3 movement = Vector3.zero;


    void Start(){
        playerRB = GetComponent<Rigidbody>();



    }
 

    // Update is called once per frame

    void Update()

    {

        // Up/Down (X-axis)

        if (Input.GetKey(KeyCode.RightArrow)) {

            // Up-slope Positive

            if (movement.x >= 0) {

                movement.x += GainPerSecond * Time.deltaTime;

                if (movement.x > maxSpeed) movement.x = maxSpeed;

            } else {

                // Break-slope Negative

                movement.x += GainPerSecond * reverseMomentum * Time.deltaTime;

                if (movement.x > 0) movement.x = 0;

            }

        } else if (Input.GetKey(KeyCode.LeftArrow)) {

            // Down-slope Negative

            if (movement.x <= 0) {

                movement.x -= GainPerSecond * Time.deltaTime;

                if (movement.x < -maxSpeed) movement.x = -maxSpeed; 

            } else {

                // Break-slope Positive

                movement.x -= GainPerSecond * reverseMomentum * Time.deltaTime;

                if (movement.x < 0 ) movement.x = 0;

            }

        } else {

            if (movement.x > 0) {

                // Fadeout from Positive

                movement.x -= LossPerSecond * Time.deltaTime;

                if (movement.x < 0 ) movement.x = 0;

            } else if (movement.x < 0) {

                // Fadeout from Negative

                movement.x += LossPerSecond * Time.deltaTime;

                if (movement.x > 0) movement.x = 0;

            }

        }

 

        // Left/Right (Y-axis)

        if (Input.GetKey(KeyCode.UpArrow)) {

            // Up-slope Positive

            if (movement.z >= 0) {

                movement.z += GainPerSecond * Time.deltaTime;

                if (movement.z > maxSpeed) movement.z = maxSpeed;

            } else {

                // Break-slope Negative

                movement.z += GainPerSecond * reverseMomentum * Time.deltaTime;

                if (movement.z > 0) movement.z = 0;

            }

        } else if (Input.GetKey(KeyCode.DownArrow)) {

            // Down-slope Negative

            if (movement.z <= 0) {

                movement.z -= GainPerSecond * Time.deltaTime;

                if (movement.z < -maxSpeed) movement.z = -maxSpeed; 

            } else {

                // Break-slope Positive

                movement.z -= GainPerSecond * reverseMomentum * Time.deltaTime;

                if (movement.z < 0 ) movement.z = 0;

            }

        } else {

            if (movement.z > 0) {

                // Fadeout from Positive

                movement.z -= LossPerSecond * Time.deltaTime;

                if (movement.z < 0 ) movement.z = 0;

            } else if (movement.z < 0) {

                // Fadeout from Negative

                movement.z += LossPerSecond * Time.deltaTime;

                if (movement.z > 0) movement.z = 0;

            }

        }

 

        if (movement.x != 0 || movement.z != 0) {

            // Only move when necessary

            var p = transform.position;

            p.x += movement.x * Time.deltaTime;

            p.z += movement.z * Time.deltaTime;

            transform.position = p;

            transform.rotation = Quaternion.Slerp(

                transform.rotation,

                Quaternion.LookRotation(movement),

                rotationSpeed

            );

 

        }

        //PLayer jumb

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;
        }


    }

    //Jump on ground up/down
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
    }

    //Game Over

    public void GameOver(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
