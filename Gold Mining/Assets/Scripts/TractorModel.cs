using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorModel : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    PlayerInputHandler playerInput;
    [SerializeField]
    TractorView tractorView;
    [SerializeField]
    Hook hook;

    [SerializeField]
    TractorMover mover;

    enum State
    {
        Idle,
        Mining,
        Moving,
    }

    State currentState;

    private void Awake()
    {
        currentState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.Idle:
                UpdateIdle();
                break;
            case State.Mining:
                UpdateMining();
                break;
            case State.Moving:
                UpdateMoving();
                break;
        }
    }

    #region Idle
    void UpdateIdle()
    {
        if(playerInput.Backspace)
        {
            StartMining();
        }
        else
        {
            if(Mathf.Abs(playerInput.Horizontal) > Mathf.Epsilon)
            {
                StartMoving();
            }
        }
    }

    void StartIdling()
    {
        currentState = State.Idle;
        tractorView.PlayIdleAnimation();
    }
    #endregion

    #region Mining
    void UpdateMining()
    {
        if(hook.currentHookState == Hook.HookState.Finished)
        {
            hook.currentHookState = Hook.HookState.Ready;
            StartIdling();
        }
    }

    void StartMining()
    {
        currentState = State.Mining;
        hook.ScanForItem();
        //use same animation
        tractorView.PlayIdleAnimation();
    }
    #endregion

    #region Moving
    void UpdateMoving()
    {
        if (playerInput.Backspace)
        {
            StartMining();
        }
        else
        {
            if (Mathf.Abs(playerInput.Horizontal) < 0.1f)
            {
                StartIdling();
            }
            else
            {
                tractorView.PlayMoveAnimation(playerInput.Horizontal);
                mover.Move(playerInput.Horizontal);
            }
        }
    }

    void StartMoving()
    {
        currentState = State.Moving;
        tractorView.PlayMoveAnimation(playerInput.Horizontal);
        mover.Move(playerInput.Horizontal);
    }
    #endregion
}
