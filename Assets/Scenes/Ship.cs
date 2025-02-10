using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    // some public variables that can be used to tune the Ship’s movement
    public Vector3 forceVector;
    public float rotationSpeed;
    public float rotation;
    // Use this for initialization
    void Start() {
        // Vector3 default initializes all components to 0.0f
        forceVector.z = 1.0f;
        rotationSpeed = 2.0f;
        GetComponent<Rigidbody>().freezeRotation = true;
    }
    /* forced changes to rigid body physics parameters should be done through the FixedUpdate()
    method, not the Update() method
    */
    void FixedUpdate() {
        // force thruster
        if (Input.GetAxisRaw("Vertical") > 0) {
            GetComponent<Rigidbody>().AddRelativeForce(forceVector);
        }
        if (Input.GetAxisRaw("Horizontal") > 0) {
            rotation += rotationSpeed;
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot);
            //gameObject.transform.Rotate(0, 2.0f, 0.0f );
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            rotation -= rotationSpeed; 
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot);
            //GetComponent<Rigidbody>().Rotate(0, -2.0f, 0.0f );
        }
    }
    public GameObject bullet; // the GameObject to spawn
    // Update is called once per frame
    void Update () {
        // if (Input.GetAxisRaw("Vertical") > 0) {
        //     gameObject.transform.Translate(0, 0, thrustSpeed);
        // }
        // if (Input.GetAxisRaw("Horizontal") > 0) {
        //     gameObject.transform.Rotate(0, turnSpeed, 0);
        // } else if (Input.GetAxisRaw("Horizontal") < 0) {
        //     gameObject.transform.Rotate(0, -turnSpeed, 0);
        // }

        Vector3 currentPosition = gameObject.transform.position;
        currentPosition.y = 0;
        gameObject.transform.position = currentPosition;

        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("Fire! " + rotation);
            /* we don’t want to spawn a Bullet inside our ship, so some
            Simple trigonometry is done here to spawn the bullet
            at the tip of where the ship is pointed.
            */
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.z += 1.0f * Mathf.Cos(rotation * Mathf.PI / 180);
            spawnPos.x += 1.0f * Mathf.Sin(rotation * Mathf.PI / 180); 
            // instantiate the Bullet
            GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
            // get the Bullet Script Component of the new Bullet instance
            BulletScript b = obj.GetComponent<BulletScript>();
            // set the direction the Bullet will travel in
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            b.heading = rot;
        }
    }
}