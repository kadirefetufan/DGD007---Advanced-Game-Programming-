using UnityEngine;

public class AutoClick : MonoBehaviour
{
    private bool hasClicked = false;

    void Start()
    {
        // Oyun baþladýðýnda bir kere týklama yap
        if (!hasClicked && Input.GetMouseButtonDown(0))
        {
            ClickFunction();
        }
    }

    void Update()
    {
        // Ýstenirse her frame'de kontrol edilebilir
        // Eðer bir kere týklama yapýlmasý yeterliyse Start metodunda yeterli olabilir
        if (!hasClicked && Input.GetMouseButtonDown(0))
        {
            ClickFunction();
        }
    }

    void ClickFunction()
    {
        // Burada otomatik týklama sonrasý yapýlmasý istenen iþlemleri gerçekleþtirin
        Debug.Log("Otomatik Týklama Yapýldý!");

        // Örneðin bir baþka metodu çaðýrabilir veya oyunu baþlatabilirsiniz.
        // Örnek: SceneManager.LoadScene("Oyun_Sahnesi");

        // hasClicked'i true olarak ayarla, bir daha týklama yapýlmasýn
        hasClicked = true;
    }
}
