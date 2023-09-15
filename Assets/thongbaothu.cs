using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class thongbaothu : MonoBehaviour
{
    public GameObject imagethu; // Kéo và thả hình ảnh của lá thư vào đây trong Unity Inspector
    public Button thuButton; // Kéo và thả nút lá thư vào đây trong Unity Inspector
    public TextMeshProUGUI letterText; // Kéo và thả đối tượng TextMeshPro vào đây trong Unity Inspector

    private string[] letterLines = { "-.-. .... .- --- / -.-. --- -. --..-- / .-.. ..- --- -- --..-- / -.- .... --- -. --. / -.. .- .. / -.. --- -. --. --..-- / -.-. .... ..- / ...- .. . - / - .... ..- / -. .- -.-- / -.. . / -. .... --- / - --- .. / ... ..- / --. .. ..- .--. / -.. --- / -.-. ..- .- / -.-. --- -. .-.-.- / -. .... ..- / -.-. --- -. / -.. .- / -... .. . - / - .... .. / - .. -. .... / .... .. -. .... / -.-. .... .. . -. / ... ..- / .... .. . -. / - .- .. / .-. .- - / -.-. .- -. --. / - .... .- -. --. --..-- / .--. .... .- .--. / -.. .- / -.-. .... .. . -- / -.. --- -. --. / -. --. --- .. / .-.. .- -. --. / .--. .... ..- --- -.-. / - .. -.-. .... .-.-.- / -.-. .- -.-. / -.. --- -. --. / -.. --- .. / .-.. .. . -. / .-.. .- .. / - .- .. / -. --- .. / -.. --- / -.-. ..- -. --. / -... .. / --.- ..- .- -. / .--. .... .- .--. / -... .- - / --. .. ..- .-.-.- / -. .... ..- -. --. / .-. .- - / -- .- -.-- / -.-. ..- -. --. / .-. .- - / -..- ..- .. / .-.. .- / .... --- / -.. .- / -.- .. .--. / --. .. .- ..- / -.. .. / -. .... ..- -. --. / -- .- - / - .... ..- / -.-. .... ..- .- / - .... --- -. --. / - .. -. / --.- ..- .- -. / - .-. --- -. --. / -.-. ..- .- / -.-. .... ..- -. --. / - .- / - .- .. / -. --. --- .. / .-.. .- -. --. / -.. --- .-.-.- / -.-. --- / .-.. . / .... .. . -. / - .- .. / -.-. --- -. / .-.. .- / -. --. ..- --- .. / .--. .... ..- / .... --- .--. / -. .... .- - / -.-. .... --- / -. .... .. . -- / ...- ..- / -. .- -.-- / ...- .- / -.-. .... ..- / - .. -. / - ..- --- -. --. / -.-. --- -. --..-- / .... .- -.-- / -.. ..- .- / -. .... ..- -. --. / -- .- - / - .... ..- / -.. --- / -.. . -. / -. --- .. / .- -. / - --- .- -. / -. .... .- - / -.-. --- / - .... . .-.-.- / --. ..- .. / .-.. --- .. / .... --- .. / - .... .- -- / -... .- / -- . / --. .. ..- .--. / -.-. .... ..- / -. .... . .-.-.- / -.-. .... ..- -.-. / -.-. --- -. / -- .- -.-- / -- .- -. .-.-.- [Nhấn ENTER để dịch mật mã]", "Chào con, Lượm. Không dài dòng, chú viết thư này để nhờ tới sự giúp đỡ của con. Như con đã biết thì tình hình chiến sự hiện tại rất căng thẳng, Pháp đã chiếm đóng ngôi làng Phước Tích. Các đồng đội liên lạc tại nơi đó cũng bị quân Pháp bắt giữ. Nhưng rất may cũng rất xui là họ đã kịp giấu đi những mật thư chứa thông tin quan trọng của chúng ta tại ngôi làng đó. Có lẽ hiện tại con là người phù hợp nhất cho nhiệm vụ này và chú tin tưởng con, hãy đưa những mật thư đó đến nơi an toàn nhất có thể. Gửi lời hỏi thăm ba mẹ giúp chú nhé. Chúc con may mắn." }; // Thay đổi này thành nội dung của lá thư
    private int currentLine = 0;
    private bool isTyping;

    void Start()
    {
        // Ẩn hình ảnh lá thư khi trò chơi bắt đầu
        imagethu.SetActive(false);

        // Thêm sự kiện nhấp chuột cho nút lá thư
        thuButton.onClick.AddListener(OnLetterButtonClick);
    }

    void Update()
    {
        // Khi người dùng nhấn phím Tab, hiển thị hoặc ẩn hình ảnh lá thư
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleLetterImage();
        }

        // Khi người dùng nhấn phím Enter, hiển thị đoạn văn tiếp theo hoặc ẩn hình ảnh lá thư nếu không còn đoạn văn nào để hiển thị
        if (Input.GetKeyDown(KeyCode.Return) && imagethu.activeSelf && !isTyping)
        {
            ShowNextLine();
        }

        // Khi người dùng nhấn phím ESC và hình ảnh lá thư đang được hiển thị, ẩn hình ảnh lá thư
        if (Input.GetKeyDown(KeyCode.Escape) && imagethu.activeSelf)
        {
            imagethu.SetActive(false);
            thuButton.gameObject.SetActive(false);
            letterText.text = "";
            currentLine = 0;
        }
    }

    public void OnLetterButtonClick()
    {
        // Khi người dùng nhấp vào nút lá thư, hiển thị hoặc ẩn hình ảnh lá thư
        ToggleLetterImage();
    }

    private void ToggleLetterImage()
    {
        // Đảo trạng thái hiển thị của hình ảnh lá thư
        bool isActive = imagethu.activeSelf;
        imagethu.SetActive(!isActive);
        thuButton.gameObject.SetActive(!isActive);

        if (isActive)
        {
            // Nếu hình ảnh lá thư đã được hiển thị, thiết lập lại văn bản và chỉ số dòng hiện tại
            letterText.text = "";
            currentLine = 0;
        }
        else
        {
            // Nếu hình ảnh lá thư đã được ẩn, hiển thị dòng đầu tiên của lá thư
            ShowNextLine();
        }
    }


    private void ShowNextLine()
    {
        // Nếu còn dòng để hiển thị, hiển thị đoạn văn tiếp theo. Nếu không, ẩn hình ảnh lá thư.
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

        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        letterText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            letterText.text += letter;
            yield return new WaitForSeconds(-10f); // Điều chỉnh tốc độ gõ ở đây
            isTyping = true;
        }
        isTyping = false;
    }
}
