using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class DestroyAfterAnimation : StateMachineBehaviour
{
    public GameObject[] nextObjectsSpawned;
    public float secondsTillSpawn;
    private float timer;

    private bool hasSpawnedItems;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = secondsTillSpawn;
        hasSpawnedItems = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (nextObjectsSpawned != null && !hasSpawnedItems)
        {
            if (timer <= 0)
            {
                foreach (var o in nextObjectsSpawned)
                {
                    Instantiate(o, animator.transform.position, Quaternion.identity);

                }
                hasSpawnedItems = true;
                timer = secondsTillSpawn;
            }
            else timer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
