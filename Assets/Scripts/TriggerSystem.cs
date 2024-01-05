using UnityEngine;

namespace JJF
{
    ///<summary>
    ///觸發系統
    ///</summary>
    public class TriggerSystem : MonoBehaviour
    {
        [SerializeField, Header("要顯示的物件")]
        private GameObject objectToShow;


       private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("Player"))
            {
                print("玩家進入觸發區域");
                objectToShow.SetActive(true);
            }
           
        }
    }
}