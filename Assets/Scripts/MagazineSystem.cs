using UnityEngine;

namespace JJF
{
    public class MagazineSystem : MonoBehaviour
    {
        [SerializeField, Header("子彈數量"), Range(1, 50)]
        private int bulletCount = 10;
        
        private string playerName = "玩家";

        //兩個碰撞器 Collider 碰撞時會執行
        private void OnCollisionEnter(Collision collision)
        {
            //如果碰到物件的名稱包含 玩家 兩個字
            if (collision.gameObject.name.Contains(playerName))
            {
                //就請開槍系統單例模式 處理 加子彈
                FireSystem.instance.AddBullet(bulletCount);
                Destroy(gameObject);
            }
        }

    }
}