using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{

    // 实体类型枚举
    // 状态机 消息 广播
    public enum Enity{ fsm,telegram,broadcast};
    // 消息 事件枚举
    public enum messageEvent { changeState,};


    // 状态机序列号
    public static int fsmId_ = 0;
    // 消息序列号
    public static int telegramId_ = 0;
    // 广播序列号
    public static int broadcastId_ = 0;


    // 生成的所有状态机
    public static Dictionary<int, FiniteStateMachine> allFiniteStateMachine = new Dictionary<int, FiniteStateMachine>();

    // 生成的所有消息事件
    public static Dictionary<int, TimeUtil> allMessageEvent = new Dictionary<int, TimeUtil>();

    // 生成的所有广播事件
    public static Dictionary<int, TimeUtil> allBroadcastEvent = new Dictionary<int, TimeUtil>();



    /// <summary>
    /// 状态机更新
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
