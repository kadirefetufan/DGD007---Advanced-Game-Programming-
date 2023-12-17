using UnityEngine;

public class ButtonVisibilityScript : MonoBehaviour
{
    public GameObject button; // G�sterilecek buton

    private void OnTriggerEnter(Collider other)
    {
        // Tetikleyici (trigger) b�lgeye giren nesnenin etiketini kontrol et
        // Bu �rnekte "Player" etiketine sahip bir nesnenin girmesi kontrol ediliyor
        if (other.CompareTag("Player"))
        {
            // E�er etiket "Player" ise, butonu g�ster
            button.SetActive(true);
        }
    }

   
}