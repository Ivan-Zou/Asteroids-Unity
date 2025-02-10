using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    public int pointValue;
    public float speed = 2.0f;
    public float rotSpeed = 50.0f;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start() {
        pointValue = 10;
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomZ = Random.Range(-1.0f, 1.0f);
        moveDirection = new Vector3(randomX, 0, randomZ).normalized;
    }

    // Update is called once per frame
    void Update() {
        Vector3 currentPosition = gameObject.transform.position;
        currentPosition.y = 0;
        gameObject.transform.position = currentPosition;
        gameObject.transform.position += moveDirection * speed * Time.deltaTime;
        gameObject.transform.Rotate(moveDirection * rotSpeed * Time.deltaTime);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (screenPosition.x < -100 || screenPosition.x > Screen.width + 100|| screenPosition.y < -100 || screenPosition.y > Screen.height + 100) {
            Destroy(gameObject);
        }
    }
    
    public GameObject deathExplosion;
    public AudioClip deathKnell;
    public void Die() {
        //Debug.Log ("OH NO I AM DYING");
        /* all of Shuriken's particle effects by default use the convention of Z being upwards,
        and XY being the horizontal plane. as a result, since we are looking down the Y axis, we rotate
        the particle system so that it flys in the right way.
        */
        AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue;
        // Destroy removes the gameObject from the scene and
        // marks it for garbage collection
        Destroy(gameObject);
    }
    
}
