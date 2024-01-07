using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using StarterAssets;
using UnityEngine.SceneManagement;



namespace JJF
{
    /// <summary>
    /// 遊戲管理器:遊戲勝利與失敗、重新與退出遊戲
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        //單例模式:靜態實體欄位
        public static GameManager instance;

        #region 介面資料
        [SerializeField, Header("結束畫面")]
        private CanvasGroup groupFinal;
        [SerializeField, Header("結束標題")]
        private TextMeshProUGUI textTitleFinal;
        [SerializeField, Header("按鈕重新遊戲")]
        private Button btnReplay;
        [SerializeField, Header("按鈕離開遊戲")]
        private Button btnQuit;
        #endregion

        #region 玩家資料
        [SerializeField, Header("開槍系統 : 手槍")]
        private FireSystem fireSystem;
        [SerializeField, Header("第一人稱控制器 : 玩家")]
        private FirstPersonController firstPersonController;
        [SerializeField, Header("輸入系統 : 玩家")]
        private StarterAssetsInputs startAssetsInputs;
        #endregion


        private void Awake()
        {
            //指定為自己
            instance = this;
            //點擊重新開始遊戲按鈕後 載入 "後室" 場景
            btnReplay.onClick.AddListener(() => SceneManager.LoadScene("後室"));
            //點擊離開遊戲按鈕後 離開遊戲 (Unity 編輯器內無效，打包後才有作用)
            btnQuit.onClick.AddListener(() => Application.Quit());
        }

        ///<summary>
        ///顯示結束畫面
        ///</summary>
        ///<param name="finalTitle">結束標題</param>
        public void ShowGameFinal(string finalTitle)
        {
            textTitleFinal.text = finalTitle;
            StartCoroutine(FadeInFinal());
            //關閉開槍系統、第一人稱控制器
            fireSystem.enabled = false;
            firstPersonController.enabled = false;
            //取消滑鼠鎖定
            startAssetsInputs.cursorLocked = false;

            //指標.鎖定狀態 = 鎖定狀態.啟動
            Cursor.lockState = CursorLockMode.Confined;
        }

        private IEnumerator FadeInFinal()
        {
            for (int i = 0; i < 10; i++) 
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.03f);
            }
            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
        }


    }
}