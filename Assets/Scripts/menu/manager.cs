using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class manager : MonoBehaviour
{
    public GameObject pauseMenu; // Đối tượng menu tạm dừng
    private bool isPaused = false; // Biến theo dõi trạng thái tạm dừng
    public Button pauseButton; // Nút tạm dừng

    private void Start()
    {
        pauseMenu.SetActive(false); // Ẩn menu tạm dừng khi bắt đầu trò chơi
        pauseButton.onClick.AddListener(PauseGame); // Thêm sự kiện OnClick cho nút tạm dừng
    }

    private void Update()
    {
        // Xử lý sự kiện nhấn phím ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
           
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Hiển thị menu tạm dừng
        Time.timeScale = 0f; // Dừng thời gian trong trò chơi
        isPaused = true; // Đánh dấu trò chơi đang tạm dừng
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Ẩn menu tạm dừng
        Time.timeScale = 1f; // Khôi phục lại thời gian trong trò chơi
        isPaused = false; // Đánh dấu trò chơi không còn tạm dừng
    }

  public void restart()
{
    isPaused = false; // Đặt lại giá trị của biến isPaused
    Time.timeScale = 1f; // Khôi phục lại thời gian trong trò chơi
    string mySavedScene = PlayerPrefs.GetString("sceneName");
    SceneManager.LoadScene(mySavedScene);
}


    public void Quitgame()
    {
        Debug.Log("QUIT");
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("menubatdau");
    }
}
