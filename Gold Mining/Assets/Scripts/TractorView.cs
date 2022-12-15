using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class TractorView : MonoBehaviour
{
    [SerializeField]
    SkeletonAnimation skeletonAnimation;

    readonly string idleAnimationName = "ingame-idle";
    readonly string moveForwardAnimationName = "move forward";
    readonly string moveBackwardAnimationName = "move backward";

    enum state
    {
        idle,
        forward,
        backward
    }

    state currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = state.idle;
    }

    public void PlayIdleAnimation()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, idleAnimationName, true);
        currentState = state.idle;
    }

    public void PlayMoveAnimation(float horizontal)
    {
        if(horizontal > Mathf.Epsilon)
        {
            if (currentState == state.forward)
                return;
            //move forward
            skeletonAnimation.AnimationState.SetAnimation(0, moveForwardAnimationName, true);
            currentState = state.forward;
        }
        else
        {
            if (currentState == state.backward)
                return;
            //move backward
            skeletonAnimation.AnimationState.SetAnimation(0, moveBackwardAnimationName, true);
            currentState = state.backward;
        }
    }
}
