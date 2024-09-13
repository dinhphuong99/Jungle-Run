using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : TurnOnOffSound
{
    public PlayerMovement playerMovement;

    public AudioSource runSource;
    public AudioSource impactSource;


    private bool hasRunSound = false;
    private bool hasImpactSound = false;

    // Start is called before the first frame update
    void Start()
    {
        StopSound(ref hasImpactSound, impactSource);
        UpdateSound(!playerMovement.isImpactPre, ref hasRunSound, runSource);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isImpactPre)
        {
            StopSound(ref hasRunSound, runSource);
            UpdateSound(playerMovement.isImpactPre, ref hasImpactSound, impactSource);
        }
    }
}
