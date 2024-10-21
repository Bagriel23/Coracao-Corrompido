using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    PlayerActions player;
    DetectInputs inputs;
    public bool hasLeftAttack, hasRightAttack;
    bool rAttack, lAttack;
    [SerializeField]private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerActions>();
        inputs = GetComponent<DetectInputs>();
    }

    private void Awake()
    {
        inputs = GetComponent<DetectInputs>();

  
        inputs.controls.PlayerInputs.AttackRight.performed += context => rAttack = true;
        inputs.controls.PlayerInputs.AttackLeft.performed += context => lAttack = true;
        inputs.controls.PlayerInputs.AttackRight.canceled += context => rAttack = false;
        inputs.controls.PlayerInputs.AttackLeft.canceled += context => lAttack = false;


    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log(player.leftMagicDamage);
     //   Debug.Log(player.rightLowerSpeedIntensity);
      //  Debug.Log(rAttack);
       // Debug.Log(lAttack);
       if(inputs!= null)
        {
            Debug.Log("CONTROLLER DETECTADO");
        }
        else
        {
            Debug.Log("CONTROLLER NAO DETECTADO!!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("ENTROU");
        DealDamage(other);
    }

    private void OnTriggerStay(Collider other)
    {
        
        DealDamage(other);
        //Debug.Log("ESTA DENTRO");
       
    }

    private void DealDamage(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && (lAttack || rAttack))
        {
            Debug.Log("O INIMIGO FOI DETECTADO");
            EnemyLife enemyLife = other.GetComponent<EnemyLife>();
            if (hasLeftAttack && lAttack)
            {
                if (enemyLife != null)
                {
                    if (enemyLife.canTakeLeftDamage)
                    {
                        enemyLife.TakeDamage(player.leftMagicDamage);
                        enemyLife.TookLeftDamage();
                    }
                }
            }
            else if (hasRightAttack && rAttack)
            {
                UnityEngine.AI.NavMeshAgent enemySpeed = other.GetComponent<UnityEngine.AI.NavMeshAgent>();
                if (enemySpeed != null)
                {
                    Debug.Log("ESTA DETECTANDO O ATAQUE DIREITO NESTE INIMIGO");
                    enemySpeed.speed = player.rightLowerSpeedIntensity;
                    enemyLife.TookRightSlow();
                }
            }

        }
    }
}
