using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;                // prevents NaN from epsilon = 0                

        float cycles = Time.time / period;                  // total cycles ran during game runs
        const float TAU = Mathf.PI * 2;                     // tau = 2 pi
        float sinWave = Mathf.Sin(cycles * TAU);            // sin radius (-1 <-> 1) as repetative cycle counter

        movementFactor = (sinWave + 1f) / 2f;               // adjust the slide runs around 0 - 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
