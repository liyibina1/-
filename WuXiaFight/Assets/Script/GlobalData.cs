using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{

    // ʵ������ö��
    // ״̬�� ��Ϣ �㲥
    public enum Enity{ fsm,telegram,broadcast};
    // ��Ϣ �¼�ö��
    public enum messageEvent { changeState,};


    // ״̬�����к�
    public static int fsmId_ = 0;
    // ��Ϣ���к�
    public static int telegramId_ = 0;
    // �㲥���к�
    public static int broadcastId_ = 0;


    // ���ɵ�����״̬��
    public static Dictionary<int, FiniteStateMachine> allFiniteStateMachine = new Dictionary<int, FiniteStateMachine>();

    // ���ɵ�������Ϣ�¼�
    public static Dictionary<int, TimeUtil> allMessageEvent = new Dictionary<int, TimeUtil>();

    // ���ɵ����й㲥�¼�
    public static Dictionary<int, TimeUtil> allBroadcastEvent = new Dictionary<int, TimeUtil>();



    /// <summary>
    /// ״̬������
    /// </summary>
    public void FsmUpdate()
    {
        //Debug.Log(fsmId_);
        //Debug.Log(allFiniteStateMachine.Count);
        if (allFiniteStateMachine.Count > 0)
        {
            foreach (FiniteStateMachine fsm in allFiniteStateMachine.Values)
            {
                fsm.UpdateFsm();
            }
        }
    }


    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        FsmUpdate();
    }
}
