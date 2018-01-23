using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxePunchAnimationScript : StateMachineBehaviour {
                                 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerHand = animator.gameObject.transform.Find("PlayerHand");
        RaycastHit2D hit = new RaycastHit2D();

        var camera = Camera.main;

        var mouse = camera.ScreenToWorldPoint(Input.mousePosition);

        var x = playerHand.transform.position.x;
        var y = playerHand.transform.position.y;

        var x1 = mouse.x;
        var y1 = mouse.y;
        var direction = new Vector2(x1, y1);
        var position = new Vector2(x, y);
        Debug.Log(position + " " + direction + " ");
        hit = Physics2D.Raycast(position, direction, 1.1f);

        if (hit.collider != null && hit.collider.gameObject != null)
        {
            Debug.Log(hit.collider);
            if (hit.collider.gameObject.tag == "destroy")
                Destroy(hit.collider.gameObject);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

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
