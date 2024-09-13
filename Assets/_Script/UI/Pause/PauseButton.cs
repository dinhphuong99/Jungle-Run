using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [HideInInspector] public static bool pause = false;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float timePause = 1.5f;
    public float playTimer = -1f;
    [SerializeField] private KeyRebindManager keyRebind;
    [SerializeField] private bool isDeath = false;

    // Update is called once per frame
    void Update()
    {
        isDeath = playerMovement.isImpactPre || playerMovement.isFallOutWorld;
        
        // Kiểm tra nếu playTimer đang chạy
        if (playTimer > 0 && pause)
        {
            playTimer -= Time.unscaledDeltaTime; // Giảm thời gian bằng Time.unscaledDeltaTime để không bị ảnh hưởng bởi Time.timeScale
            if (playTimer <= 0)
            {
                Time.timeScale = 1f; // Khôi phục tốc độ thời gian sau khi hết thời gian dừng
            }
        }
        
        if (isDeath)
        {
            StartCoroutine(HandleDeath());
        }
        else if (keyRebind.isPause && !isDeath)
        {
            if (pause)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    private IEnumerator HandleDeath()
    {
        pause = true;
        yield return new WaitForSeconds(timePause);
        Time.timeScale = 0f;
        deathPanel.SetActive(true);
    }

    public void Play()
    {
        pause = false;

        playTimer = timePause; // Bắt đầu đếm thời gian dừng trước khi khôi phục Time.timeScale
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
    }

    public void Stop()
    {
        Time.timeScale = 0f;
        pause = true;
        pausePanel.SetActive(true);
        deathPanel.SetActive(false);
    }
}
