using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float offset = 0.1f;
    public float mag = 10.0f;
    public float freq = 10.0f;
    public float mag2 = 1.0f;
    public float freq2 = 1.0f;
    public float offset2 = 0.2f;
    
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = mag * Vector3.up * Mathf.Sin(freq * Time.time + offset) + mag2 * Vector3.right * Mathf.Cos(freq2 * Time.time + offset2);
    }
}
