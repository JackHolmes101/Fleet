using Assets.Code.Common;
using System;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
internal class Placement: MonoBehaviour
{
    public GameObject player;
    private FSMSystem fsm;

    public void SetTransition(Transition t) { fsm.PerformTransition(t); }

    public void Start()
    {
        MakeFSM();
    }

    public void FixedUpdate()
    {
        fsm.CurrentState.Reason(player, gameObject);
        fsm.CurrentState.Act(player, gameObject);
    }

    // The NPC has two states: FollowPath and ChasePlayer
    // If it's on the first state and SawPlayer transition is fired, it changes to ChasePlayer
    // If it's on ChasePlayerState and LostPlayer transition is fired, it returns to FollowPath
    private void MakeFSM()
    {
        InactiveState inactive = new InactiveState(gameObject);
        inactive.AddTransition(Transition.Placed, StateID.Active);

        ActiveState active = new ActiveState(gameObject);
        active.AddTransition(Transition.Removed, StateID.Inactive);
        active.AddTransition(Transition.Deactivated, StateID.Disabled);

        DisabledState disabled = new DisabledState(gameObject);
        disabled.AddTransition(Transition.Activated, StateID.Active);

        fsm = new FSMSystem();
        fsm.AddState(inactive);
        fsm.AddState(active);
        fsm.AddState(disabled);
    }
}

public class InactiveState : FSMState
{
    GameObject gameObject;

    public InactiveState(GameObject GO)
    {
        stateID = StateID.Inactive;
        gameObject = GO;
    }

    public override void DoBeforeEntering()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<ChangeColour>().R = 1;
        gameObject.GetComponent<ChangeColour>().G = 0;
        gameObject.GetComponent<ChangeColour>().B = 0;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        
        //Debug.Log("InactiveState Reason");
    }

    public override void Act(GameObject player, GameObject npc)
    {
        //Debug.Log("InactiveState Act");
    }
}

public class ActiveState : FSMState
{ 
    GameObject gameObject;

    public ActiveState(GameObject GO)
    {
        stateID = StateID.Active;
        gameObject = GO;
    }

    public override void DoBeforeEntering()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<ChangeColour>().R = 0;
        gameObject.GetComponent<ChangeColour>().G = 1;
        gameObject.GetComponent<ChangeColour>().B = 0;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        //Debug.Log("ActiveState Reason");
    }

    public override void Act(GameObject player, GameObject npc)
    {
        //Debug.Log("ActiveState Reason");
    }
}

public class DisabledState : FSMState
{
    GameObject gameObject;

    public DisabledState(GameObject GO)
    {
        stateID = StateID.Disabled;
        gameObject = GO;
    }

    public override void DoBeforeEntering()
    {
        gameObject.GetComponent<ChangeColour>().R = 0;
        gameObject.GetComponent<ChangeColour>().G = 0;
        gameObject.GetComponent<ChangeColour>().B = 1;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        //Debug.Log("DisableState Reason");
    }

    public override void Act(GameObject player, GameObject npc)
    {
        //Debug.Log("DisableState Act");
    }
}

/////////////////////////////////////////////////////////////////////////////////////////

//public class FollowPathState : FSMState
//{
//    private int currentWayPoint;
//    private Transform[] waypoints;

//    public FollowPathState(Transform[] wp)
//    {
//        waypoints = wp;
//        currentWayPoint = 0;
//        stateID = StateID.FollowingPath;
//    }

//    public override void Reason(GameObject player, GameObject npc)
//    {
//        // If the Player passes less than 15 meters away in front of the NPC
//        RaycastHit hit;
//        if (Physics.Raycast(npc.transform.position, npc.transform.forward, out hit, 15F))
//        {
//            if (hit.transform.gameObject.tag == "Player")
//                npc.GetComponent<NPCControl>().SetTransition(Transition.SawPlayer);
//        }
//    }

//    public override void Act(GameObject player, GameObject npc)
//    {
//        // Follow the path of waypoints
//        // Find the direction of the current way point 
//        Vector3 vel = npc.rigidbody.velocity;
//        Vector3 moveDir = waypoints[currentWayPoint].position - npc.transform.position;

//        if (moveDir.magnitude < 1)
//        {
//            currentWayPoint++;
//            if (currentWayPoint >= waypoints.Length)
//            {
//                currentWayPoint = 0;
//            }
//        }
//        else
//        {
//            vel = moveDir.normalized * 10;

//            // Rotate towards the waypoint
//            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
//                                                      Quaternion.LookRotation(moveDir),
//                                                      5 * Time.deltaTime);
//            npc.transform.eulerAngles = new Vector3(0, npc.transform.eulerAngles.y, 0);

//        }

//        // Apply the Velocity
//        npc.rigidbody.velocity = vel;
//    }

//} // FollowPathState

//public class ChasePlayerState : FSMState
//{
//    public ChasePlayerState()
//    {
//        stateID = StateID.ChasingPlayer;
//    }

//    public override void Reason(GameObject player, GameObject npc)
//    {
//        // If the player has gone 30 meters away from the NPC, fire LostPlayer transition
//        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 30)
//            npc.GetComponent<NPCControl>().SetTransition(Transition.LostPlayer);
//    }

//    public override void Act(GameObject player, GameObject npc)
//    {
//        // Follow the path of waypoints
//        // Find the direction of the player 		
//        Vector3 vel = npc.rigidbody.velocity;
//        Vector3 moveDir = player.transform.position - npc.transform.position;

//        // Rotate towards the waypoint
//        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
//                                                  Quaternion.LookRotation(moveDir),
//                                                  5 * Time.deltaTime);
//        npc.transform.eulerAngles = new Vector3(0, npc.transform.eulerAngles.y, 0);

//        vel = moveDir.normalized * 10;

//        // Apply the new Velocity
//        npc.rigidbody.velocity = vel;
//    }

//} // ChasePlayerState