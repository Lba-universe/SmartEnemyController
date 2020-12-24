using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//  This component represents an Smart mode controller
//  Coward: The enemy chooses, from the targets on his list the most far target from the player.
//  Brave: The enemy chooses, from the targets on his list the closest target to the player. 
//  Chaser: The enemy chases players. 
//  DestoryEngine to the engine: The enemy tries to reach the middle of the building (to destory him)


[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    enum ModeSwitching { None, Chaser, Brave, Coward, DestoryEngine };
    [Tooltip("Control the enemy behavior")]
    [SerializeField] private ModeSwitching EnemyMode;

    [Tooltip("Enemy will Destory this GameObject")]
    [SerializeField] private GameObject Engine = null;

    [Tooltip("Enemy will chase this GameObject")]
    [SerializeField] private GameObject Player = null;

    [Tooltip("A game object whose children have a Target component. Each child represents a target.")]
    [SerializeField] private Transform targetFolder = null;

    private Target[] allTargets = null;
    private NavMeshAgent navMeshAgent;
    private EnemyMovement enemyMovement;


    // Start is called before the first frame update
    void Start()
    {

        // Exception in case user didnt set our necessary fields
        if (Player == null || Engine == null || targetFolder == null)
            throw new Exception("Please set Player, targetFolder and Engine Fields");

        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        // EnemyMode = ModeSwitching.None; should be None when init but i wanted to upload it to itch.io

        // get components in active children only
        allTargets = targetFolder.GetComponentsInChildren<Target>(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyMode != ModeSwitching.None)
        {
            switch (EnemyMode)
            {
                // chaser mode is chasing player
                case ModeSwitching.Chaser:
                    navMeshAgent.SetDestination(Player.transform.position);
                    enemyMovement.target = Player.transform;
                    break;

                // brave mode is searching the closest points target to player - 2 == Brave in the enum
                case ModeSwitching.Brave:
                    var targetBrave = distanceFromPlayer(2);
                    navMeshAgent.SetDestination(targetBrave.transform.position);
                    enemyMovement.target = targetBrave.transform;
                    break;
                // coward mode is searching the most far points target to player - 3 == coward in the enum
                case ModeSwitching.Coward:
                    var targetCoward = distanceFromPlayer(3);
                    navMeshAgent.SetDestination(targetCoward.transform.position);
                    enemyMovement.target = targetCoward.transform;
                    break;

                // DestoryEngine mode is chasing Engine
                case ModeSwitching.DestoryEngine:
                    navMeshAgent.SetDestination(Engine.transform.position);
                    enemyMovement.target = Engine.transform;
                    break;
            }
        }
    }

    // this method find a target from TargetFolder by comparing distance
    // if type is 2 (Brave) then target is the closest to player
    // else type is 3 (Coward) then target is the most far from player
    private Target distanceFromPlayer(int type)
    {
        var target = allTargets[0];
        foreach(var t in allTargets) {
            if (target.name != t.name) {
                float distance_t1_to_player = Vector3.Distance(target.transform.position, Player.transform.position);
                float distance_t2_to_player = Vector3.Distance(t.transform.position, Player.transform.position);

                // type is brave
                if (type == 2)
                    target = distance_t1_to_player < distance_t2_to_player ? target : t;
                // type is coward
                else
                    target = distance_t1_to_player > distance_t2_to_player ? target : t;
            }
        }
        return target;
    }
}
