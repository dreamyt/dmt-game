using UnityEngine;
using UnityEngine.UI;

public class TestScroll1 : MonoBehaviour
{

    //����ScrollRect����
    ScrollRect rect;

    void Start()
    {
        //��ȡ ScrollRect����
        rect = this.GetComponent<ScrollRect>();
    }

    void Update()
    {
        //��Update�����е���ScrollValue����
        ScrollValue();
    }

    private void ScrollValue()
    {
        //����Ӧֵ����1�����¿�ʼ�� 0 ��ʼ
        //if (rect.verticalNormalizedPosition > 1.0f)
       // {
        //    rect.verticalNormalizedPosition = 0;
        //}

        //�𽥵ݼ� ScrollRect ��ֱ�����ϵ�ֵ
        rect.verticalNormalizedPosition = rect.verticalNormalizedPosition - 0.02f * Time.deltaTime;
    }

}