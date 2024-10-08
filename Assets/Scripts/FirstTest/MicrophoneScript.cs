using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MicrophoneScript : MonoBehaviour
{

   

    private AudioClip clip;
        

    public int sampleWindow = 64;
    // Start is called before the first frame update
    void Start()
    {
      
        MicrophoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if Volume < x
    }

    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        clip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), clip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if(startPosition < 0)
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        //compute Loudness
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;
    }

}
