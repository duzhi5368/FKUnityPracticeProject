using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;

public class MainManager : MonoBehaviour
{
    [Serializable]
    class SaveData
    {
        public int Score;
        public string Name;
    }

    public void SaveDataToFile()
    {
        SaveData data = new SaveData();
        data.Name = strName;
        data.Score = maxPoint;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/myData.json", json);
    }

    public void LoadDataFromFile()
    {
        string path = Application.persistentDataPath + "/myData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxPoint = data.Score;
            strName = data.Name;
        }
    }

    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverText;
    public GameObject HighScoreUIs;
    [SerializeField] private TMP_InputField nameInputField;
    
    private bool m_Started = false;
    private int m_Points;
    private int maxPoint;
    private string strName = "Hi";
    
    private bool m_GameOver = false;

    private void Awake()
    {
        LoadDataFromFile();
    }

    private void OnApplicationQuit()
    {
        SaveDataToFile();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadDataFromFile();
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        BestScoreText.text = "Best Score : " + maxPoint + " Name : " + strName;
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = UnityEngine.Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {

        if (m_Points >= maxPoint)
        {
            HighScoreUIs.SetActive(true);
        }
        else
        {
            m_GameOver = true;
            GameOverText.SetActive(true);
        }
    }

    public void OnHighScoreButtonClick()
    {
        maxPoint = m_Points;
        strName = nameInputField.text;
        SaveDataToFile();
        nameInputField.text = "";
        HighScoreUIs.SetActive(false);

        m_GameOver = true;
        GameOverText.SetActive(true);
    }
}
