using UnityEngine;


namespace JJF
{
    /// <summary>
    /// 敵人受傷
    /// </summary>
    public class DamageEnemy : DamageSystem
    {
        private string nameBullet = "子彈";

        //當物件碰撞開始會執行一次的事件
        private void OnCollisionEnter(Collision collision)
        {
            //如果碰到物件的名稱包含 "子彈" 就受傷
            if (collision.gameObject.name.Contains(nameBullet))
            {
                Damage(30);
            }
        }



    }
}