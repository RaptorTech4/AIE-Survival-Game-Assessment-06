using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    void Start()
    {
        target = PlayerManager.Instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();

    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        agent.SetDestination(target.position);

        if (distance <= agent.stoppingDistance)
        {
            CharacterStats targetStats = target.GetComponent<CharacterStats>();
            if (targetStats != null)
            {

                combat.Attack(targetStats);

            }
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
