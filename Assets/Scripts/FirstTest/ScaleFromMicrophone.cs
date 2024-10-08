using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaleFromMicrophone : MonoBehaviour
{
    public AudioSource source;
    
    public MicrophoneScript mic;
    
    public float loudnessSensibility = 10f;
    public float threshold = 0.1f;
    public SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        float loudness = mic.GetLoudnessFromMicrophone() * loudnessSensibility;

       

        if (loudness > threshold)
            SceneManager.LoadScene(1);
            
        print(loudness);


    }
}
