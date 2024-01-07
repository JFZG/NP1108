using UnityEngine;


namespace JJF
{
    /// <summary>
    /// 敵人受傷
    /// </summary>
    [DefaultExecutionOrder(100)]
    public class DamageEnemy : DamageSystem
    {
        [SerializeField, Header("受傷特效")]
        private GameObject effectDamage;
        [SerializeField, Header("死亡特效")]
        private GameObject effectDead;
        [SerializeField, Header("受傷特效持續時間")]
        private float timeToDestroyDamage = 1;
        [SerializeField, Header("死亡特效持續時間")]
        private float timeToDestroyDead = 2;
        [SerializeField, Header("受傷音效")]
        private AudioClip soundDamage;
        [SerializeField, Header("敵人死亡爆炸音效")]
        private GameObject soundDead;


        private string nameBullet = "子彈";
        private Vector3 pointBullet;
        private AudioSource aud;

        protected override void Awake()
        {
            base.Awake();
            aud = GetComponent<AudioSource>();

            //訂閱玩家走到出口的事件 並執行 玩家走到出口方法
            ExitManager.instance.onExit += PlayerExit;
        }

        /// <summary>
        /// 玩家進入出口
        /// </summary>
        private void PlayerExit()
        {
            Damage(9999);
        }

        //當物件碰撞開始會執行一次的事件
        private void OnCollisionEnter(Collision collision)
        {
            //如果碰到物件的名稱包含 "子彈" 就受傷
            if (collision.gameObject.name.Contains(nameBullet))
            {
                //紀錄子彈座標
                pointBullet = collision.transform.position;
                Damage(30);
            }
        }

        public override void Damage (float damage)
        {
            base.Damage(damage);
            //受傷特效 = 生成(受傷特效，子彈座標，零角度)
            GameObject tempDamage = Instantiate(effectDamage, pointBullet, Quaternion.identity);
            //刪除(受傷特效物件，延遲刪除時間)
            Destroy(tempDamage, timeToDestroyDamage);
            //播放一次受傷音效，隨機音量
            aud.PlayOneShot(soundDamage, Random.Range(1f, 2f));

        }

        protected override void Dead()
        {
            base.Dead();
            //死亡特效 = 生成(死亡特效，角色座標+高度，零角度) 
            GameObject tempDead = Instantiate(effectDead, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            //刪除(死亡特效，刪除持續時間)
            Destroy(tempDead, timeToDestroyDead);
            //刪除(此物件)
            Destroy(gameObject);

            //生成死亡爆炸音效
            GameObject tempDeadSound = Instantiate(soundDead, transform.position, Quaternion.identity);
            //延遲兩秒後刪除死亡爆炸音效物件
            Destroy(tempDeadSound, 2);
        }
    }
}