using UnityEngine;

namespace JJF
{
    ///<summary>
    ///Ĳ�o�t��
    ///</summary>
    public class TriggerSystem : MonoBehaviour
    {
        [SerializeField, Header("�n��ܪ�����")]
        private GameObject objectToShow;


       private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("Player"))
            {
                print("���a�i�JĲ�o�ϰ�");
                objectToShow.SetActive(true);
            }
           
        }
    }
}