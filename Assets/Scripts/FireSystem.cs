using TMPro;
using UnityEngine;
using System.Collections;

namespace JJF
{
    /// <summary>
    /// 開槍系統
    /// </summary>

    public class FireSystem : MonoBehaviour
    {
        [SerializeField, Header("子彈預置物")]
        private GameObject prefabBullet;
        [SerializeField, Header("槍口")]
        private Transform pointGun;
        [SerializeField, Header("子彈數量文字")]
        private TextMeshProUGUI textBulletCount;
        [Header("音效")]
        [SerializeField]
        private AudioClip soundFire, soundReload, soundNoBullet;

        private AudioSource aud;

        public static FireSystem instance;

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

        private bool isReloading;

        private string stringBulletCount=> $"{currentBulletCount}/{totalBulletCount}";
        private float randomVolume => Random.Range(0.8f, 1.5f);

        private void Awake()
        {
            instance = this;
            aud = GetComponent<AudioSource>();
            textBulletCount.text = stringBulletCount;
        }

        private void Update()
        {
            FireBullet();
            Reload();
        }

        /// <summary>
        /// 發射子彈
        /// </summary>
        private void FireBullet()
        {
            //如果 換彈夾中 就跳出
            if (isReloading) return;

            if (Input.GetKeyDown(KeyCode.Mouse0) && currentBulletCount > 0)
            {
                Instantiate(prefabBullet, pointGun.position, pointGun.rotation);
                currentBulletCount--;

                textBulletCount.text = stringBulletCount;
                aud.PlayOneShot(soundFire, randomVolume);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && currentBulletCount == 0)
            {
                aud.PlayOneShot(soundNoBullet, randomVolume);
            }
        }

        ///<summy>
        ///換彈夾
        ///</summy>
        private void Reload()
        {
            //如果 按下 R 並且 尚未換彈夾
            if (Input.GetKeyDown(KeyCode.R) && !isReloading)
            {
                //如果 沒子彈 或者 目前子彈是滿的 就 跳出
                if (totalBulletCount == 0 || currentBulletCount == magazine) return;

                StartCoroutine(Reloading());
            }
        }

        private IEnumerator Reloading()
        {
            //換彈夾中...
            aud.PlayOneShot(soundReload, 1.2f);
            isReloading = true;
            print("<color=#f69>開始換彈夾</color>");
            //等兩秒
            yield return new WaitForSeconds(2);
            //換完彈夾
            isReloading = false;
            print("<color=#6f9>換完彈夾</color>");

            //要填加的數量 = 彈夾 - 當前
            int countToAdd = magazine - currentBulletCount;

            //如果 總數 小於 要添加的數量 ， 要添加的數量 = 總數
            if (totalBulletCount < countToAdd) countToAdd = totalBulletCount;

            //當前 += 要添加的數量
            currentBulletCount += countToAdd;
            //總數 -= 要添加的數量
            totalBulletCount -= countToAdd;

            //更新介面
            textBulletCount.text = stringBulletCount;

        }

        ///<summary>
        ///添加子彈
        ///</summary>
        ///<param name="bulletCount">要添加的數量</param>
        public void AddBullet(int bulletCount)
        {
            totalBulletCount += bulletCount;
            textBulletCount.text = stringBulletCount;
        }
    }
}