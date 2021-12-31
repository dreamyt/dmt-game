using UnityEngine;
using UnityEngine.UI;

public class TestScroll1 : MonoBehaviour
{

    //设置ScrollRect变量
    ScrollRect rect;

    void Start()
    {
        //获取 ScrollRect变量
        rect = this.GetComponent<ScrollRect>();
    }

    void Update()
    {
        //在Update函数中调用ScrollValue函数
        ScrollValue();
    }

    private void ScrollValue()
    {
        //当对应值超过1，重新开始从 0 开始
        //if (rect.verticalNormalizedPosition > 1.0f)
       // {
        //    rect.verticalNormalizedPosition = 0;
        //}

        //逐渐递减 ScrollRect 竖直方向上的值
        rect.verticalNormalizedPosition = rect.verticalNormalizedPosition - 0.02f * Time.deltaTime;
    }

}