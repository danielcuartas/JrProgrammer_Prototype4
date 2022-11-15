using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rB;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    private float vInput;
    public float forwardSpeed;
    public bool hasPowerup = false;
    private float powerupStrength = 15.0f;
    private int powerupTime = 7;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        rB.AddForce(focalPoint.transform.forward * forwardSpeed * Time.deltaTime * vInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }
    }

    IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(powerupTime);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("collision with: " + collision.gameObject.name + "with powerup set to " + hasPowerup);
            Rigidbody EnemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            EnemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            
        }
    }
}
