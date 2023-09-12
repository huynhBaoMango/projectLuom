using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class thongbaothu : MonoBehaviour
{
    public GameObject imagethu; // Kéo và thả hình ảnh của lá thư vào đây trong Unity Inspector
    public Button thuButton; // Kéo và thả nút lá thư vào đây trong Unity Inspector
    public TextMeshProUGUI letterText; // Kéo và thả đối tượng TextMeshPro vào đây trong Unity Inspector

    private string[] letterLines = { ".-..-. -.-. .... # / -... ..-.. / .-.. # # -- / - .... .--.- -. / -- # -. --..-- .- -. .... / -.-. ---. / -- # - / -. .... .. # -- / ...- # / --.- ..- .- -. / - .-. # -. --. / -.-. # -. / . -- / --. .. # .--. .-.-.- / .- -. .... / -.-. # -. / . -- / -. .... # - / - .... # / -. .--.- -.-- / ...- .--.- / # # .- / -. ---. / # # -. / -- # - / -. --. ---. .. / .-.. .--.- -. --. / # .- -. --. / -.-. .... # ..- / ... # / - .--.- -. / .--. .... .--.- / -.-. # .- / -.-. .... .. # -. / - .-. .- -. .... .-.-.- / # # .- / # .. # -- / -. .--.- -.-- / -. # -- / - .-. --- -. --. / -- # - / -.- .... ..- / .-. # -. --. / ... .--.- ..- / - .... # -- --..-- / -. # .. / -.-. ---. / -. .... .. # ..- / -.-. --- -. / -.. # -.-. / # .--.- / -. --. ..- -.-- / .... .. # -- / ...- .--.- / -.. ---. -. --. / ... ---. -. --. / -.-. .... # -.-- / -..- .. # - .-.-.- .-..-. / - .-. --- -. --. / - .... # .. / - .. # - / -- # .- / -. .... # / .... .. # -. / -. .- -.-- --..-- / - # -- / -. .... .---. -. / -.-. # .- / -.- # / # # -.-. .... / ... # / -... # / .... # -. / -.-. .... # .-.-.- / -. .... # -. --. / .... .--.- -.-- / -. .... # / .-. # -. --. --..-- / -.- .... .. / -.-. ---. / -..- ..-.. - --..-- / - # -- / -. .... .---. -. / -.-. # .- / .... # / ... # / # # # -.-. / -- # / .-. # -. --. .-.-.- / ...- .---. / ...- # -.-- --..-- / .... .--.- -.-- / .-.. ..- ---. -. / -.-. # -. / - .... # -. / ...- .--.- / -.- .... ---. -. --. / # # / .-.. # / -... # -. / - .... .--.- -. .-.-.- .... .--.- -.-- / -.-. # -. / - .... # -. --..-- / .-.. # # -- / # .-.-.- / -.-. .... # -.-. / . -- / -- .- -.-- -- # -. .-.-.- - .-. .--.- -. / - .-. # -. --. --..-- / .- -. .... / .-.. # -. .... nhấn enter để giải mã","Chú bé Lượm thân mến,Anh có một nhiệm vụ quan trọng cần em giúp. Anh cần em nhặt thư này và đưa nó đến một ngôi làng đang chịu sự tàn phá của chiến tranh. Địa điểm này nằm trong một khu rừng sâu thẳm, nơi có nhiều con dốc đá nguy hiểm và dòng sông chảy xiết.Trong thời tiết mưa như hiện nay, tầm nhìn của kẻ địch sẽ bị hạn chế. Nhưng hãy nhớ rằng, khi có xét, tầm nhìn của họ sẽ được mở rộng. Vì vậy, hãy luôn cẩn thận và không để lộ bản thân.Hãy cẩn thận, Lượm ạ. Chúc em maymắn.Trân trọng, Anh lính nhấn, enter để tắt"}; // Thay đổi này thành nội dung của lá thư
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
            isTyping=true;
        }
        isTyping= false;
    }
}
