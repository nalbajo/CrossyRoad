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
        // �г� ����
        gameStartPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        // �÷��̾� - ī�޶� ��ġ ���� ���� �� ��Ȱ��ȭ
        playerObject.SetActive(false);
        playerObject.transform.position = spawnPos.position;
        cameraObject.transform.position = spawnCamera.position;
    }
    private void GameStart()
    {
        gameStartPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        playerObject.transform.position = spawnPos.position;	// ���� ��ġ �ʱ�ȭ
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
        if (Instance == null) // Instance�� null�̸�
        {
            Instance = this; // �Ҵ�
            DontDestroyOnLoad(gameObject); // ����ȯ�� ���� X
        }
        else // null�� �ƴϸ� -> �̹� �ִٴ� ��
        {
            Destroy(gameObject); // �ϳ��� �����ؾ��ϹǷ� ����
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
