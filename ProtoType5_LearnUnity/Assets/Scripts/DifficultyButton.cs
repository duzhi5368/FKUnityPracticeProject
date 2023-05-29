using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int diffcultLevel;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDiffculty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDiffculty()
    {
        gameManager.StartGame(diffcultLevel);
    }
}
