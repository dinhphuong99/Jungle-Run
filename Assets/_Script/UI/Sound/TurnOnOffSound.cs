using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSound(bool condition, ref bool hasPlayed, AudioSource audioSource)
    {
        if (condition)
        {
            if (!hasPlayed)
            {
                audioSource.Play();
                hasPlayed = true;
            }
        }
        else
        {
            if (hasPlayed)
            {
                audioSource.Stop();
                hasPlayed = false;
            }
        }
    }

    public void StopSound(ref bool hasPlayed, AudioSource audioSource)
    {
        if (hasPlayed)
        {
            audioSource.Stop();
            hasPlayed = false;
        }
    }
}
