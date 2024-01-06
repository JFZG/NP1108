using UnityEngine.AI;
using UnityEngine;
using System.Collections;

namespace JJF
{ 
    /// <summary>
    /// 敵人AI
    /// </summary>
    public class EnemyAI : MonoBehaviour
    {
        #region 欄位資料
        [SerializeField, Header("移動速度"), Range(0, 10)]
        private float moveSpeed = 2.5f;
        [SerializeField, Header("停止距離"), Range(0, 10)]
        private float stopDistance = 1.5f;
        [SerializeField, Header("造成玩家傷害時間"), Range(0, 3)]
        private float takePlayerDamageTime = 0.8f;
        [SerializeField, Header("關閉攻擊區域時間"), Range(0, 3)]
        private float closeAttackAreaTime = 0.5f;
        [SerializeField, Header("攻擊冷卻"), Range(0, 5)]
        private float attackCD = 2.5f;
        [SerializeField, Header("敵人攻擊區域")]
        private GameObject attackArea;

        private NavMeshAgent agent;
        private Transform playerPoint;
        private Animator ani;
        private string parMove = "加速度";
        private string parAttack = "觸發攻擊";
        private bool isAttack;
        #endregion

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = moveSpeed;
            agent.stoppingDistance = stopDistance;
            ani = GetComponent<Animator>();


            //玩家點 = 搜尋名稱為 "玩家" 的物件並取得變形元件
            playerPoint = GameObject.Find("玩家").transform;
        }

        private void Update()
        {
            //代理器.設定目的地(玩家的座標)
            agent.SetDestination(playerPoint.position);

            //代理器.加速度(三維向量).大小(浮點數)
            float move = agent.velocity.magnitude;
            //動畫.市定浮點數(浮點數參數名稱，浮點數值)
            ani.SetFloat(parMove, move / moveSpeed);

            //距離 = 三維向量.距離(A，B)
            float distance = Vector3.Distance(playerPoint.position, transform.position);
            //print($"<color=#96f>距離:{distance}</color>");

            //如果 距離 <= 停止距離 並且 尚未攻擊
            if (distance <= stopDistance && !isAttack)
            {
                StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack()
        {
            //攻擊動畫觸發
            ani.SetTrigger(parAttack);
            //已經攻擊
            isAttack = true;
            //代理器.停止 = 是
            agent.isStopped = true;
            //等待0.8秒造成玩家傷害
            yield return new WaitForSeconds(takePlayerDamageTime);
            //顯示攻擊區域
            attackArea.SetActive(true);
            yield return new WaitForSeconds(closeAttackAreaTime);
            //等待2.5秒冷卻恢復可攻擊
            yield return new WaitForSeconds(attackCD);
            isAttack = false;
            agent.isStopped = false;

        }


        

    }
}
