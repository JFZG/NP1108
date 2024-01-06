using UnityEngine;

namespace JJF
{

    /// <summary>
    /// 子彈 : 攻擊力與刪除處理
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        [Header("子彈攻擊力"), Range(0, 1000)]
        public float attack = 30;

        private void Awake()
        {
            Destroy(gameObject, 3);

        }
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

    }
}