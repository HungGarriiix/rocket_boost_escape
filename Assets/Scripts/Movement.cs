using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotate = 100f;
    [SerializeField] AudioClip thrusterSound;

    AudioSource audioSource;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(thrusterSound);
        }
        else
        {
            audioSource.Stop();
        }
            
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            ApplyRotation(rotate);
        else if (Input.GetKey(KeyCode.RightArrow))
            ApplyRotation(-rotate);
    }

    private void ApplyRotation(float rotateThisFrame)
    {
        // Rick's solution
        /*rb.freezeRotation = true;   // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateThisFrame);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over*/

        // Rand's solution
        rb.angularVelocity += Vector3.forward * Time.deltaTime * rotateThisFrame;

        // Nina's solution (to make the delay longer than Rick's)
        /*RigidbodyConstraints constraints = rb.constraints;
        rb.freezeRotation = false;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateThisFrame);
        rb.constraints = constraints;*/
    }
}
