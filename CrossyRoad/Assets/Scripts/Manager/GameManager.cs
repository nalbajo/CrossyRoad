using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private GameObject gameStartPanel;
    [SerializeField] private Button startBtn;

    [SerializeField] private Transform spawnPos;
    [SerializeField] private Button retryBtn;

    [SerializeField] private GameObject cameraObject;
    [SerializeField] private Transform spawnCamera;

    public UnityEvent OnPlayerDied = new UnityEvent();

    private void Start()
    {
        ShowStartUI();
    }
    private void ShowStartUI()
    {
        // 패널 상태
        gameStartPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        // 플레이어 - 카메라 위치 원점 복구 및 비활성화
        playerObject.SetActive(false);
        playerObject.transform.position = spawnPos.position;
        cameraObject.transform.position = spawnCamera.position;
    }
    private void GameStart()
    {
        gameStartPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        playerObject.transform.position = spawnPos.position;	// 스폰 위치 초기화
        cameraObject.transform.position = spawnCamera.position;
    }

    private void OnEnable()
    {
        
        OnPlayerDied.AddListener(GameOver);
        retryBtn.onClick.AddListener(GameStart);
        startBtn.onClick.AddListener(GameStart);
    }
 
    private void Awake()
    {
        if (Instance == null) // Instance가 null이면
        {
            Instance = this; // 할당
            DontDestroyOnLoad(gameObject); // 씬전환간 삭제 X
        }
        else // null이 아니면 -> 이미 있다는 뜻
        {
            Destroy(gameObject); // 하나만 존재해야하므로 삭제
        }
    }

    private void OnDisable()
    {
        OnPlayerDied.RemoveListener(GameOver);
        retryBtn.onClick.RemoveListener(GameStart);
    }
    public void GameOver()
    {
        playerObject.SetActive(false);

        gameOverPanel.SetActive(true);
    }

}
