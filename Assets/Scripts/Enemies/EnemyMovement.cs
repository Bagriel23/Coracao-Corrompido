using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    DetectInputs inputs;
    private Animator anim;
    private Transform player;
    private UnityEngine.AI.NavMeshAgent selfAgent;
    private float speed = 4f;
    public bool hasSeparateAttack, isSlowSignVisible = false;
    private EnemyLife life;
    [SerializeField] private bool rAttack = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        selfAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        life = GetComponent<EnemyLife>();
    }
    private void Awake()
    {
        inputs = GetComponent<DetectInputs>();

        inputs.controls.PlayerInputs.AttackRight.performed += context => rAttack = true;
        inputs.controls.PlayerInputs.AttackRight.canceled += context => rAttack = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (hasSeparateAttack)
        {
            MoveTowardsPlayerWithSpeedParameter();
        }
        else
        {
            MoveTowardsPlayer();
        }

        if (selfAgent.speed != speed && !isSlowSignVisible)
        {
            life.ShowSlowSign();
            isSlowSignVisible = true;
        }
        else if (selfAgent.speed == speed && isSlowSignVisible)
        {
            life.HideSlowSign();
            isSlowSignVisible = false;
        }
    }

    private void MoveTowardsPlayerWithSpeedParameter()
    {
        if (player != null && !anim.GetBool("AttackPlayer"))
        {
            anim.SetFloat("Speed", speed);
            //if (!rAttack) return;
            if (!isSlowSignVisible)
            {
                selfAgent.speed = speed;
            }
            selfAgent.destination = player.position;
        }
        else
        {
            selfAgent.destination = this.transform.position;
        }

    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            anim.SetFloat("Speed", speed);
            //if (!rAttack) return;
            if (!isSlowSignVisible)
            {
                selfAgent.speed = speed;
            }
            selfAgent.destination = player.position;
        }
        else
        {
            selfAgent.destination = this.transform.position;
        }

    }



}
