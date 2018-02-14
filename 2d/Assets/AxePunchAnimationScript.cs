using Assets.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxePunchAnimationScript : StateMachineBehaviour {

    public GameObject Axe;

    private GameObject CurrentAxe { get; set; }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var player = animator.gameObject;
        if (player == null) return;

        var weapon = player.transform.Find("PlayerHand");

        if (weapon == null) return;

        CurrentAxe = Instantiate(Axe, weapon.transform.position, weapon.rotation);      
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (CurrentAxe != null)
        {
            Destroy(CurrentAxe);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {                                                                                  
        animator.SetFloat("Punch", 0);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
