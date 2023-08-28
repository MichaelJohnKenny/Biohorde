using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer mixer;
    private float volumeUpperLimit;
    


    // Start is called before the first frame update
    void Start()
    {
        //volumeUpperLimit = ;
    }

    public void changeVolume (float volumeLevel)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(volumeLevel) * 20) ;
    }
}
