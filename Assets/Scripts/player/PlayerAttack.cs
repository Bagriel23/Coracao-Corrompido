using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    DetectInputs inputs;
    Vector3 hitBoxPosition;
    public float attackRadius;
    float distanceInFront = 1.5f;
    [SerializeField] private bool attack;

    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<DetectInputs>();

    }
    private void Awake()
    {
        inputs = GetComponent<DetectInputs>();


        inputs.controls.PlayerInputs.Attack.performed += context => attack = true;
        inputs.controls.PlayerInputs.Attack.canceled += context => attack = false;
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    private void Attack()
    {
        if (attack)
        {

            hitBoxPosition = this.transform.position + this.transform.forward * distanceInFront;

            Vector3 hitBoxSize = new Vector3(attackRadius, attackRadius, attackRadius);

            Collider[] enemiesToDamage = Physics.OverlapBox(hitBoxPosition, hitBoxSize / 2, Quaternion.identity);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                EnemyLife enemyLife = enemiesToDamage[i].GetComponent<EnemyLife>();
                if (enemyLife != null)
                {
                    enemyLife.TakeDamage(1);
                }
            }
        }
    }
}
