using UnityEngine;


namespace JJF
{
    /// <summary>
    /// 開槍系統
    /// </summary>

    public class FlySystem : MonoBehaviour
    {
        [SerializeField, Header("子彈預置物")]
        private GameObject prefabBullet;
        [SerializeField, Header("槍口")]
        private Transform pointGun;

        /// <summary>
        /// 目前子彈數量
        /// </summary>
        private int currentBulletCount = 5;
        /// <summary>
        /// 彈夾數量
        /// </summary>
        private int magazine = 7;
        /// <summary>
        /// 子彈總數
        /// </summary>
        private int totalBulletCount = 21;

        private void Update()
        {
            FireBullet();
            
        }

        /// <summary>
        /// 發射子彈
        /// </summary>
        private void FireBullet()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && currentBulletCount > 0)
            {
                Instantiate(prefabBullet, pointGun.position, pointGun.rotation);
                currentBulletCount--;

                print($"<color=#f69>目前子彈數量:{currentBulletCount} </ color >");
            }

        }
    }
}