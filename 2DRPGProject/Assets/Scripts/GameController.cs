using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EGameState 
{
    EGameState_Normal,
    EGameState_Dialog,
    EGmaeState_Battle,
}

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private EGameState eGameState;

    // Start is called before the first frame update
    void Start()
    {
        // 初始化事件处理
        DialogManager.Instance.OnShowDialog += () =>
        {
            eGameState = EGameState.EGameState_Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (eGameState == EGameState.EGameState_Dialog)
            {
                eGameState = EGameState.EGameState_Normal;
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        switch (eGameState)
        {
            case EGameState.EGameState_Normal:
                playerController.HandleUpdate();
                break;
            case EGameState.EGameState_Dialog:
                DialogManager.Instance.HandleUpdate();
                break;
            case EGameState.EGmaeState_Battle:
                break;
            default:
                break;
        }
    }
}
