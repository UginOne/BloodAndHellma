using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachiGunScript : StateMachineBehaviour
{          
    public GameObject bullet;
            
    [SerializeField]
    float bulletSpeed = 10f;
    [SerializeField]
    [Range(1, 5)]
    private int shootCount = 4; // выстрелов одновременно, например
    [Range(1, 5)]
    private int currentShootCount = 0; // выстрелов одновременно, например
    [SerializeField]
    [Range(0.9f, 1f)]
    private float accuracy = 1; // разброс пуль, 1 = 100% точности
                                            
    public Transform weapon;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {    
        animator.SetFloat("Punch", 0);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
