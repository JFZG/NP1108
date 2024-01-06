using UnityEngine.AI;
using UnityEngine;


namespace JJF
{ 
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 10)]
        private float moveSpeed = 2.5f;
        [SerializeField, Header("停止距離"), Range(0, 10)]
        private float stopDistance = 1.5f;

        private NavMeshAgent agent;
        private Transform playerPoint;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = moveSpeed;
            agent.stoppingDistance = stopDistance;


            //玩家點 = 搜尋名稱為 "玩家" 的物件並取得變形元件
            playerPoint = GameObject.Find("玩家").transform;
        }

        private void Update()
        {
            //代理氣.設定目的地(玩家的座標)
            agent.SetDestination(playerPoint.position);
        }

    }
}
