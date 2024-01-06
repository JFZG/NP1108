using UnityEngine;

namespace JJF
{
    /// <summary>
    /// 受傷基底系統 : 血量、受傷與死亡方法
    /// </summary>
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("血量"), Range(0, 100)]
        private float hp = 100;

        private float hpMax;

        private void Awake()
        {
            //血量最大值 = 遊戲開始的血量
            hpMax = hp;
        }
        
        ///<summary>
        ///受傷方法
        ///</summary>
        ///<param name="damage">造成的傷害</param>
        public void Damage(float damage)
        {
            hp -= damage;
            //血量 = 數學.夾住(血量，0，血量最大值)
            hp = Mathf.Clamp(hp, 0, hpMax);

            if (hp <= 0) Dead();
        }

        ///<summary>
        ///死亡
        ///</summary>
        private void Dead()
        {
            print("<color=#69f>死亡</color>");
        }

    }
}