using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("基本参数")]
    [SerializeField, Tooltip("游戏角色的移动速度")]
    private float moveSpeed;
    [SerializeField, Tooltip("物件碰撞层")]
    private LayerMask solidItemsLayer;
    [SerializeField, Tooltip("NPC碰撞层")]
    private LayerMask npcLayer;

    private bool isMoving;
    private Vector2 inputCache;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            inputCache.x = Input.GetAxisRaw("Horizontal");
            inputCache.y = Input.GetAxisRaw("Vertical");

            // 禁止斜向移动，并赋予左右移动更高的优先权
            if(inputCache.x != 0)
            {
                inputCache.y = 0;
            }

            if(inputCache != Vector2.zero)
            {
                // 通知动画器进行动画调整
                animator.SetFloat("moveX", inputCache.x);
                animator.SetFloat("moveY", inputCache.y);

                var targetPos = transform.position;
                targetPos.x += inputCache.x;
                targetPos.y += inputCache.y;

                // 检测目标点是否可以移动
                if (IsWalkable(targetPos))
                {
                    // 实际坐标移动
                    StartCoroutine(MoveTo(targetPos));
                }
            }
        }

        // 调整动画
        animator.SetBool("isMoving", isMoving);

        // 尝试和NPC交互
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryToInteract();
        }
    }

    IEnumerator MoveTo(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        return Physics2D.OverlapPoint(targetPos, solidItemsLayer | npcLayer) == null;
    }

    private void TryToInteract()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        // 绘制角色观察线段
        Debug.DrawLine(transform.position, interactPos, Color.red, 1.0f);

        // 再次用 小圆 去检测是否有NPC在角色观察线段顶点
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, npcLayer);
        if(collider == null)
        {
            return;
        }

        // 处理NPC交互内容
        collider.GetComponent<Interactable>()?.Interact();
    }
}
