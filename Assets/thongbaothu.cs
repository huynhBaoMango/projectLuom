using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class thongbaothu : MonoBehaviour
{
    public GameObject imagethu; 
    public Button thuButton; 
    public TextMeshProUGUI letterText; 

    private string[] letterLines = {
        "-.-. .... .- --- / -.-. --- -. --..-- / .-.. ..- --- -- --..-- / -.- .... --- -. --. / -.. .- .. / -.. --- -. --. --..-- / -.-. .... ..- / ...- .. . - / - .... ..- / -. .- -.-- / -.. . / -. .... --- / - --- .. / ... ..- / --. .. ..- .--. / -.. --- / -.-. ..- .- / -.-. --- -. .-.-.- / -. .... ..- / -.-. --- -. / -.. .- / -... .. . - / - .... .. / - .. -. .... / .... .. -. .... / -.-. .... .. . -. / ... ..- / .... .. . -. / - .- .. / .-. .- - / -.-. .- -. --. / - .... .- -. --. --..-- / .--. .... .- .--. / -.. .- / -.-. .... .. . -- / -.. --- -. --. / -. --. --- .. / .-.. .- -. --. / .--. .... ..- --- -.-. / - .. -.-. .... .-.-.- / -.-. .- -.-. / -.. --- -. --. / -.. --- .. / .-.. .. . -. / .-.. .- .. / - .- .. / -. --- .. / -.. --- / -.-. ..- -. --. / -... .. / --.- ..- .- -. / .--. .... .- .--. / -... .- - / --. .. ..- .-.-.- / -. .... ..- -. --. / .-. .- - / -- .- -.-- / -.-. ..- -. --. / .-. .- - / -..- ..- .. / .-.. .- / .... --- / -.. .- / -.- .. .--. / --. .. .- ..- / -.. .. / -. .... ..- -. --. / -- .- - / - .... ..- / -.-. .... ..- .- / - .... --- -. --. / - .. -. / --.- ..- .- -. / - .-. --- -. --. / -.-. ..- .- / -.-. .... ..- -. --. / - .- / - .- .. / -. --. --- .. / .-.. .- -. --. / -.. --- .-.-.- / -.-. --- / .-.. . / .... .. . -. / - .- .. / -.-. --- -. / .-.. .- / -. --. ..- --- .. / .--. .... ..- / .... --- .--. / -. .... .- - / -.-. .... --- / -. .... .. . -- / ...- ..- / -. .- -.-- / ...- .- / -.-. .... ..- / - .. -. / - ..- --- -. --. / -.-. --- -. --..-- / .... .- -.-- / -.. ..- .- / -. .... ..- -. --. / -- .- - / - .... ..- / -.. --- / -.. . -. / -. --- .. / .- -. / - --- .- -. / -. .... .- - / -.-. --- / - .... . .-.-.- / --. ..- .. / .-.. --- .. / .... --- .. / - .... .- -- / -... .- / -- . / --. .. ..- .--. / -.-. .... ..- / -. .... . .-.-.- / -.-. .... ..- -.-. / -.-. --- -. / -- .- -.-- / -- .- -. .-.-.-       [nhấn enter để giải mã morse]",
        "Chào con, Lượm. Không dài dòng, chú viết thư này để nhờ tới sự giúp đỡ của con. Như con đã biết thì tình hình chiến sự hiện tại rất căng thẳng, Pháp đã chiếm đóng ngôi làng Phước Tích. Các đồng đội liên lạc tại nơi đó cũng bị quân Pháp bắt giữ. Nhưng rất may cũng rất xui là họ đã kịp giấu đi những mật thư chứa thông tin quan trọng của chúng ta tại ngôi làng đó. Có lẽ hiện tại con là người phù hợp nhất cho nhiệm vụ này và chú tin tưởng con, hãy đưa những mật thư đó đến nơi an toàn nhất có thể. Gửi lời hỏi thăm ba mẹ giúp chú nhé. Chúc con may mắn."
    };
    private int currentLine = 0;
    private bool isTyping;

    void Start()
    {
        imagethu.SetActive(false);
        thuButton.onClick.AddListener(OnLetterButtonClick);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleLetterImage();
        }

        if (Input.GetKeyDown(KeyCode.Return) && imagethu.activeSelf && !isTyping)
        {
            ShowNextLine();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && imagethu.activeSelf)
        {
            imagethu.SetActive(false);
            thuButton.gameObject.SetActive(false);
            letterText.text = "";
            currentLine = 0;
            Time.timeScale = 1f; // Resume the game time
        }
    }

    public void OnLetterButtonClick()
    {
        ToggleLetterImage();
    }

    private void ToggleLetterImage()
    {
        bool isActive = imagethu.activeSelf;
        imagethu.SetActive(!isActive);
        thuButton.gameObject.SetActive(!isActive);

        if (isActive)
        {
            letterText.text = "";
            currentLine = 0;
            Time.timeScale = 1f; // Resume the game time
        }
        else
        {
            Time.timeScale = 0f; // Pause the game time
            ShowNextLine();
        }
    }

    private void ShowNextLine()
    {
        if (currentLine < letterLines.Length)
        {
            StartCoroutine(TypeSentence(letterLines[currentLine]));
            currentLine++;
        }
        else
        {
            imagethu.SetActive(false);
            thuButton.gameObject.SetActive(false);
            letterText.text = "";
            currentLine = 0;
            Time.timeScale = 1f; // Resume the game time
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        letterText.text = "";
        
		foreach (char letter in sentence.ToCharArray())
		{
			letterText.text += letter;
			yield return new WaitForEndOfFrame(); // Wait for the end of frame to continue typing, even when the game time is paused
		}
	}
}
