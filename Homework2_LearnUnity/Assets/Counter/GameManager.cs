using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button restartButton;
    private List<Counter> counterList = new List<Counter>();
    public Text CounterText;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(OnClickRestartButton);
        GameObject[] boxerArray = GameObject.FindGameObjectsWithTag("Boxer");
        for(int i = 0; i < boxerArray.Length; i++)
        {
            counterList.Add(boxerArray[i].GetComponent < Counter >());
        }

        StartCoroutine(ShowRestartButton());
    }

    IEnumerator ShowRestartButton()
    {
        yield return new WaitForSeconds(5);
        restartButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateTextNotice()
    {
        int totalCount = 0;
        foreach (Counter counter in counterList)
        {
            totalCount += counter.Count;
        }
        CounterText.text = "Score : " + totalCount;
    }
}
