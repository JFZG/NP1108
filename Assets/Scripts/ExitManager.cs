using UnityEngine;


namespace JJF
{
    /// <summary>
    /// 出口管理器
    /// </summary>
    [DefaultExecutionOrder(0)]
    public class ExitManager : MonoBehaviour
    {
        public static ExitManager instance;

        private string playerName = "玩家";

        public delegate void OnExit();
        public event OnExit onExit;

        private void Awake()
        {
            instance = this;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(playerName)) PlayerInExitArea();
        }

        ///<summary>
        ///玩家進入出口區域
        ///</summary>
        private void PlayerInExitArea()
        {
            GameManager.instance.ShowGameFinal("成功逃出後室");
            //有值才能呼叫
            onExit?.Invoke();
        }

    }
}