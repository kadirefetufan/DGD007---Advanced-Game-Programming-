using UnityEngine;

public class CanvasTrigger : MonoBehaviour
{
    public GameObject canvas; // Unity'de baðlamak istediðiniz Canvas nesnesini sürükleyip býrakýn
    private bool characterStopped = false;
    private float timer = 0f;
    private float waitTime = 3f; // Bekleme süresi (3 saniye)

    private void Update()
    {
        // Eðer karakter durduysa, süre sayacýný baþlat
        if (characterStopped)
        {
            timer += Time.deltaTime;

            // Belirtilen süre kadar bekledikten sonra Canvas'ý etkinleþtir
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
        // Eðer etkileþime giren nesnenin tag'i "man" ise
        if (other.CompareTag("Player"))
        {
            characterStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Eðer etkileþim alanýndan çýkan nesnenin tag'i "man" ise
        if (other.CompareTag("Player"))
        {
            // Karakter tekrar hareket ettiðinde süre sayacýný sýfýrla
            characterStopped = false;
            timer = -50f;

            // Canvas'ý devre dýþý býrak
            if (canvas != null)
            {
                canvas.SetActive(false);
            }
        }
    }
}
