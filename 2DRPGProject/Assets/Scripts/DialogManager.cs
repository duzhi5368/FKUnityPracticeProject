using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private int lettersPerSecond;
    public event Action OnShowDialog;
    public event Action OnHideDialog;
    private int currentLine = 0;
    private bool isTypeText;
    private Dialog dialog;
    public static DialogManager Instance { get; private set; }

    public void Awake()
    {
        if(Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !isTypeText)
        {
            ++currentLine;
            if(currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false);
                currentLine = 0;

                // 发出事件修改状态
                OnHideDialog?.Invoke();
            }
        }
    }
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();

        // 事件通知
        OnShowDialog?.Invoke();

        // 保存变量
        this.dialog = dialog;

        // 实际显示
        dialogBox.SetActive(true);
        //dialogText.text = dialog.Lines[0];
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string line)
    {
        isTypeText = true;

        dialogText.text = "";
        foreach(var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1.0f / lettersPerSecond);
        }

        isTypeText = false;
    }
}
