using UnityEngine.AI;
using UnityEngine;
using System.Collections;

namespace JJF
{ 
    /// <summary>
    /// �ĤHAI
    /// </summary>
    public class EnemyAI : MonoBehaviour
    {
        #region �����
        [SerializeField, Header("���ʳt��"), Range(0, 10)]
        private float moveSpeed = 2.5f;
        [SerializeField, Header("����Z��"), Range(0, 10)]
        private float stopDistance = 1.5f;
        [SerializeField, Header("�y�����a�ˮ`�ɶ�"), Range(0, 3)]
        private float takePlayerDamageTime = 0.8f;
        [SerializeField, Header("�����N�o"), Range(0, 5)]
        private float attackCD = 2.5f;

        private NavMeshAgent agent;
        private Transform playerPoint;
        private Animator ani;
        private string parMove = "�[�t��";
        private string parAttack = "Ĳ�o����";
        private bool isAttack;
        #endregion

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = moveSpeed;
            agent.stoppingDistance = stopDistance;
            ani = GetComponent<Animator>();


            //���a�I = �j�M�W�٬� "���a" ������è��o�ܧΤ���
            playerPoint = GameObject.Find("���a").transform;
        }

        private void Update()
        {
            //�N�z��.�]�w�ت��a(���a���y��)
            agent.SetDestination(playerPoint.position);

            //�N�z��.�[�t��(�T���V�q).�j�p(�B�I��)
            float move = agent.velocity.magnitude;
            //�ʵe.���w�B�I��(�B�I�ưѼƦW�١A�B�I�ƭ�)
            ani.SetFloat(parMove, move / moveSpeed);

            //�Z�� = �T���V�q.�Z��(A�AB)
            float distance = Vector3.Distance(playerPoint.position, transform.position);
            //print($"<color=#96f>�Z��:{distance}</color>");

            //�p�G �Z�� <= ����Z�� �åB �|������
            if (distance <= stopDistance && !isAttack)
            {
                StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack()
        {
            //�����ʵeĲ�o
            ani.SetTrigger(parAttack);
            //�w�g����
            isAttack = true;
            //�N�z��.���� = �O
            agent.isStopped = true;
            //����0.8��y�����a�ˮ`
            yield return new WaitForSeconds(takePlayerDamageTime);
            print("<color=#f99>�y�����a�ˮ`</color>");
            //����2.5��N�o��_�i����
            yield return new WaitForSeconds(attackCD);
            isAttack = false;
            agent.isStopped = false;

        }


        

    }
}
