using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ToolTipManager : MonoBehaviour
{
    public string sceneName; // 이동할 씬의 이름
    private RectTransform rectTransform;
    private BoxCollider boxCollider;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        boxCollider = GetComponent<BoxCollider>();

        ResizeCollider();
    }

    private void ResizeCollider()
    {
        Vector2 size = rectTransform.rect.size;
        boxCollider.size = new Vector3(size.x, size.y, 1f);
    }


    private void OnMouseDown()
    {
        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
