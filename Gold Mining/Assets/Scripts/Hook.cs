using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public enum HookState
    {
        Ready,
        IsMining,
        Finished,
    }

    public HookState currentHookState;

    [SerializeField]
    float maxDepth;

    [SerializeField]
    LayerMask itemLayer;

    [SerializeField]
    float hookSpeed = 3;

    public void ScanForItem()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, maxDepth, itemLayer.value);
        StartCoroutine(Mining(hit.transform));
        currentHookState = HookState.IsMining;
    }

    IEnumerator Mining(Transform target = null)
    {
        //helper struct
        LerpPosition lerpPosition = new LerpPosition();

        Vector2 startPosition = transform.position;
        float startYposition = transform.position.y;

        #region Go Down
        Vector3 destination;
        if(target != null)
        {
            destination = new Vector3(transform.position.x, target.position.y, 0);
            
        }
        else
        {
            //destination is the bottom of the screen
            destination = new Vector3(transform.position.x, transform.position.y - maxDepth, 0);
        }
        yield return lerpPosition.PositionLerp(transform, destination, hookSpeed);
        #endregion

        #region Go Back Up
        if(target != null)
        {
            Vector3 itemDestination = new Vector3(target.position.x, startPosition.y, 0);
            //will decrease the hookspeed in the future
            StartCoroutine(lerpPosition.PositionLerp(target, itemDestination, hookSpeed));
            yield return lerpPosition.PositionLerp(transform, startPosition, hookSpeed);
            ExtractGold(target.GetComponent<Item>());
            Destroy(target.gameObject);
        }
        else
        {
            yield return lerpPosition.PositionLerp(transform, startPosition, hookSpeed);
        }
        #endregion
        currentHookState = HookState.Finished;
    }

    void ExtractGold(Item item)
    {
        //will extract the gold in the future
    }
}
