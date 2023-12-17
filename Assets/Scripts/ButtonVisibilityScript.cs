using UnityEngine;

public class ButtonVisibilityScript : MonoBehaviour
{
    public GameObject button; // Gösterilecek buton

    private void OnTriggerEnter(Collider other)
    {
        // Tetikleyici (trigger) bölgeye giren nesnenin etiketini kontrol et
        // Bu örnekte "Player" etiketine sahip bir nesnenin girmesi kontrol ediliyor
        if (other.CompareTag("Player"))
        {
            // Eðer etiket "Player" ise, butonu göster
            button.SetActive(true);
        }
    }

   
}