using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : TurnOnOffSound
{
    public PlayerMovement playerMovement;

    public AudioSource jumpSource;
    public AudioSource rollSource;


    private bool hasPlayedJumpSound = false;
    private bool hasPlayedRollSound = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.isGrounded)
        {
            StopSound(ref hasPlayedRollSound, rollSource);
            UpdateSound(!playerMovement.isGrounded, ref hasPlayedJumpSound, jumpSource);
        }
        else
        {
            StopSound(ref hasPlayedJumpSound, jumpSource);
            if (playerMovement.isCround)
            {
                UpdateSound(playerMovement.isCround, ref hasPlayedRollSound, rollSource);
            }
            else
            {
                StopSound(ref hasPlayedRollSound, rollSource);
            }
        }
    }

    
}
