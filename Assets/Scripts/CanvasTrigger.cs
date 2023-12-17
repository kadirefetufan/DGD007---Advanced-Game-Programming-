using UnityEngine;

public class CanvasTrigger : MonoBehaviour
{
    public GameObject canvas; // Unity'de ba�lamak istedi�iniz Canvas nesnesini s�r�kleyip b�rak�n
    private bool characterStopped = false;
    private float timer = 0f;
    private float waitTime = 3f; // Bekleme s�resi (3 saniye)

    private void Update()
    {
        // E�er karakter durduysa, s�re sayac�n� ba�lat
        if (characterStopped)
        {
            timer += Time.deltaTime;

            // Belirtilen s�re kadar bekledikten sonra Canvas'� etkinle�tir
            if (timer >= waitTime)
            {
                if (canvas != null)
                {
                    canvas.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // E�er etkile�ime giren nesnenin tag'i "man" ise
        if (other.CompareTag("Player"))
        {
            characterStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // E�er etkile�im alan�ndan ��kan nesnenin tag'i "man" ise
        if (other.CompareTag("Player"))
        {
            // Karakter tekrar hareket etti�inde s�re sayac�n� s�f�rla
            characterStopped = false;
            timer = -50f;

            // Canvas'� devre d��� b�rak
            if (canvas != null)
            {
                canvas.SetActive(false);
            }
        }
    }
}
