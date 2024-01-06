using UnityEngine.AI;
using UnityEngine;


namespace JJF
{ 
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField, Header("���ʳt��"), Range(0, 10)]
        private float moveSpeed = 2.5f;
        [SerializeField, Header("����Z��"), Range(0, 10)]
        private float stopDistance = 1.5f;

        private NavMeshAgent agent;
        private Transform playerPoint;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = moveSpeed;
            agent.stoppingDistance = stopDistance;


            //���a�I = �j�M�W�٬� "���a" ������è��o�ܧΤ���
            playerPoint = GameObject.Find("���a").transform;
        }

        private void Update()
        {
            //�N�z��.�]�w�ت��a(���a���y��)
            agent.SetDestination(playerPoint.position);
        }

    }
}
