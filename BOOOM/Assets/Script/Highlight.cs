using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    // Start is called before the first frame update


    private SpriteRenderer spriteRenderer;
    private bool isMouseOver = false;
    public TextMeshProUGUI explanationText;
    public Sprite sprite1; // ��Inspector����з���
    public Sprite sprite2; // ��Inspector����з���

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        explanationText.enabled = false;
        spriteRenderer.sprite = sprite1;
    }

    // Update is called once per frame
    private void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //这是摄像机到鼠标的一条射线。
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Ray Activated");
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("debug: 1");
                explanationText.enabled = true;
                if (!isMouseOver)
                {
                    isMouseOver = true;
                    spriteRenderer.sprite = sprite2;
                }
            }
        }
        else
        {
            explanationText.enabled = false;
            if (isMouseOver)
            {
                
                isMouseOver = false;
                spriteRenderer.sprite = sprite1;
            }
        }
    }
    // 这段代码的错误是，如果鼠标在物体上，但是物体被其他物体遮挡了，那么就会出现问题。
}

    

