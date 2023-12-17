using UnityEngine;

public class AutoClick : MonoBehaviour
{
    private bool hasClicked = false;

    void Start()
    {
        // Oyun ba�lad���nda bir kere t�klama yap
        if (!hasClicked && Input.GetMouseButtonDown(0))
        {
            ClickFunction();
        }
    }

    void Update()
    {
        // �stenirse her frame'de kontrol edilebilir
        // E�er bir kere t�klama yap�lmas� yeterliyse Start metodunda yeterli olabilir
        if (!hasClicked && Input.GetMouseButtonDown(0))
        {
            ClickFunction();
        }
    }

    void ClickFunction()
    {
        // Burada otomatik t�klama sonras� yap�lmas� istenen i�lemleri ger�ekle�tirin
        Debug.Log("Otomatik T�klama Yap�ld�!");

        // �rne�in bir ba�ka metodu �a��rabilir veya oyunu ba�latabilirsiniz.
        // �rnek: SceneManager.LoadScene("Oyun_Sahnesi");

        // hasClicked'i true olarak ayarla, bir daha t�klama yap�lmas�n
        hasClicked = true;
    }
}
