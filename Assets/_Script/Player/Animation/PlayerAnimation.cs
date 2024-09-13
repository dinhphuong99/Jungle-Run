using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerMovement playerMovement;

    Animator anim;
    bool isCround = false;
    bool isGround = false;
    bool isImpact = false;

    bool checkMovement = false;

    private string currentState;

    public AnimationClip idle;
    public AnimationClip impact;
    public AnimationClip roll;
    public AnimationClip jump;
    public AnimationClip run;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!checkMovement && this.gameObject.transform.parent)
        {
            playerMovement = this.gameObject.transform.root.GetComponent<PlayerMovement>();
            checkMovement = true;
        }
        else
        {
            checkMovement = false;
        }

        if(playerMovement != null)
        {
            isGround = playerMovement.isGrounded;

            if (playerMovement.isCround)
            {
                isCround = true;
            }
            else if(!isGround)
            {
                isCround = false;
            }
            
            isImpact = playerMovement.isImpactPre;
        }
        else
        {
            isCround = false;
            isGround = false;
            isImpact = false;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (playerMovement == null)
        {
            //ChangeAnimationState("Idle");
            ChangeAnimationClip(idle);
        }
        else if (isImpact)
        {
            //ChangeAnimationState("Fall back");
            ChangeAnimationClip(impact);
        }
        else if (isCround)
        {
            //ChangeAnimationState("Roll");
            ChangeAnimationClip(roll);
        }
        else if (!isGround)
        {
            //ChangeAnimationState("Jump");
            ChangeAnimationClip(jump);
        }
        else if (isGround)
        {
            //ChangeAnimationState("Run");
            ChangeAnimationClip(run);
        }
        else
        {
            //ChangeAnimationState("Idle");
            ChangeAnimationClip(idle);
        }  
    }

    private void ChangeAnimationState(string newState)
    {
        if (anim == null)
        {
            Debug.LogError("Animator is not assigned!");
            return;
        }

        if (string.IsNullOrEmpty(newState))
        {
            Debug.LogError("New state is null or empty!");
            return;
        }

        if (!anim.HasState(0, Animator.StringToHash(newState)))
        {
            Debug.LogError("New state is not a valid animator state: " + newState);
            return;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(newState))
        {
            return;
        }

        currentState = newState;
        anim.Play(currentState);
    }

    private void ChangeAnimationClip(AnimationClip clip)
    {
        ChangeAnimationState(clip.name);
    }

    public void SetCroundStop()
    {
        isCround = false;
        UpdateAnimationState();
    }
}
