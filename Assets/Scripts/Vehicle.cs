using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public Transform player;
    public bool vehicleActive;
    bool isInTransition;
    public Transform seatPoint;
    public Vector3 sittinoffset;
    public Transform exitPoint;
    [Space]
    public float transitionSpeed = 0.2f;

    private void Update()
    {
        if (vehicleActive && isInTransition) Exit();
        else if (!vehicleActive && isInTransition) Enter();

        if (Input.GetKeyDown(KeyCode.E))
        {
            isInTransition = true;
        }
    }

    private void Enter()
    {
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;

        player.position = Vector3.Lerp(player.position, seatPoint.position + sittinoffset, transitionSpeed);
        player.rotation = Quaternion.Slerp(player.rotation, seatPoint.rotation, transitionSpeed);

        if(player.position == seatPoint.position + sittinoffset) { isInTransition = false; vehicleActive = true; }

    }
    
    void Exit()
    {
        player.position = Vector3.Lerp(player.position, exitPoint.position, transitionSpeed);

        if(player.position == exitPoint.position) { isInTransition = false;vehicleActive = false;}

        player.GetComponent<CapsuleCollider>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
    }
}
