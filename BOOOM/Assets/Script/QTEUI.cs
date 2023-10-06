using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QTEUI : MonoBehaviour
{
    public Image img_moveImage;
    public Image img_targetImage;
    private RectTransform m_Trans;
    private RectTransform trans_Target;
    private RectTransform trans_Move;
    private int currentHicht;
    private int speed;
    private int moveTargetPos;
    private Vector3 moveDirection;
    public Text text_HitNum;
    private int hitNum;
    private void Awake() {
        m_Trans = GetComponent<RectTransform>();
        trans_Target = img_targetImage.GetComponent<RectTransform>();
        trans_Move = img_moveImage.GetComponent<RectTransform>();
    }
    // 初始化Qte条  自身高度，所在坐标，触发范围所在位置，触发范围占比
    private void Start()
    {
        InitQteUI(100,new Vector3(0,0,0),50,20,100);
    }
    public void InitQteUI(int myHight,Vector3 pos,int targetPos,int targetHight,int _speed)
    {
        currentHicht = myHight;
        m_Trans .sizeDelta = new Vector2(20,myHight);
        trans_Move.anchoredPosition = new Vector2(0,-40);
        UpdateTargetImage(targetPos,targetHight);
        speed = _speed;
        SwitchPoint();
        hitNum = 0;
    }
    private void FixedUpdate() 
    {
        trans_Move.position += moveDirection * Time.deltaTime * speed;
        if(Mathf.Abs(moveTargetPos - trans_Move.localPosition.y) <= 1)
        {
            SwitchPoint();
        }
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            if(InRange())
            {
                hitNum ++;
                text_HitNum.text = string.Format("触发次数{0}",hitNum);
            }
        }
    }
    private void UpdateTargetImage(int pos, int hight)
    {
 
        float c_hight = 0;
        if(pos -(currentHicht/2) > 0)
        {
            c_hight = pos -(currentHicht/2) - (hight/2);
        }
        else
        {
            c_hight =  pos -(currentHicht/2) + (hight/2);
        }
        
        trans_Target.sizeDelta = new Vector2(20,hight);
        trans_Target .anchoredPosition = new Vector2(0,c_hight);
    }
    private void SwitchPoint(){
        if(Mathf.Abs(currentHicht/2 -trans_Move.localPosition.y) >Mathf.Abs(-(currentHicht/2) - trans_Move.localPosition.y))
        {
            moveTargetPos = currentHicht/2;
            moveDirection = Vector3.up;
        }
        else
        {
            moveTargetPos = -(currentHicht/2);
            moveDirection = Vector3.down;
        }
    }
    private bool InRange()
    {
        float rangeMax = trans_Target.localPosition.y + trans_Target.rect.height;
        float rangeMin = trans_Target.localPosition.y - trans_Target.rect.height;
        
        float moveMax = trans_Move.localPosition.y + trans_Move.rect.height;
        float moveMin = trans_Move.localPosition.y - trans_Move.rect.height;
        if(moveMax<=rangeMax && moveMin >= rangeMin)
        {
            return true;
        }
        return false;
    }
 
}