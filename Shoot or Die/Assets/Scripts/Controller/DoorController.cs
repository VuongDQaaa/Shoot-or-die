using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform player;
    [SerializeField] private Transform door;
    [SerializeField] GamePlayController gamePlayController;
    [SerializeField] PlayerController playerController;
    private float distance;

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, door.position);
        if (distance <= 25 
        && gamePlayController.stage3 == false
        && gamePlayController.killedEnemyStage2 == 4
        && playerController.haveKey == true )
        {
            anim.SetBool("Open", true);
        }
        else
        {
            anim.SetBool("Open",false);
        }
    }
}
