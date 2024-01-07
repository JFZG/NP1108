using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JJF
{
    /// <summary>
    /// 玩家受傷
    /// </summary>
    public class DammagePlayer : DamageSystem
    {
        [SerializeField, Header("血條圖片")]
        private Image imgHp;
        [SerializeField, Header("血條文字")]
        private TextMeshProUGUI textHp;

        private string enemyAttackAreaName = "敵人攻擊區域";

        public override void Damage(float damage)
        {
            base.Damage(damage);
            imgHp.fillAmount = hp / hpMax;
            textHp.text = $"{hp}/{imgHp}";
        }

        protected override void Dead()
        {
            base.Dead();
            GameManager.instance.ShowGameFinal("挑戰失敗");
        }


        // 觸發事件
        // 1.需要兩個碰撞器
        // 2.其中一個勾選 Is Trigger
        // 3.任一個有剛體 Rigidbody 或者角色控制器 Character Controller
        private void OnTriggerEnter(Collider other)
        {
            //print($"<color=#f89>碰到物件:{other.name}</color>");

            if (other.name.Contains(enemyAttackAreaName))
            {
                float attack = other.GetComponent<EnemyAttackObject>().attack;
                Damage(attack);

            }

        }



    }
}