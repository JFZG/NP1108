using UnityEngine;

namespace JJF
{

    /// <summary>
    /// �l�u : �����O�P�R���B�z
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        [Header("�l�u�����O"), Range(0, 1000)]
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