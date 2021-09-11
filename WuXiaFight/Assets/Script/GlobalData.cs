using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static GlobalData;

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

    // 声名 委托 事件函数
    public delegate void Todo(params object[] elements_);

    // 生成的所有状态机
    //public static ChangeableDictionary allFiniteStateMachine = new ChangeableDictionary(Enity.fsm);
    public static Dictionary<int, FiniteStateMachine> allFiniteStateMachine = new Dictionary<int, FiniteStateMachine>();
    // 生成的所有消息事件
    //public static ChangeableDictionary allMessageEvent = new ChangeableDictionary(Enity.telegram);
    public static Dictionary<int, TimeUtil> allMessageEvent = new Dictionary<int, TimeUtil>();
    // 生成的所有广播事件
    //public static ChangeableDictionary allBroadcastEvent = new ChangeableDictionary(Enity.broadcast);
    public static Dictionary<int, TimeUtil> allBroadcastEvent = new Dictionary<int, TimeUtil>();
    /// <summary>
    /// 根据id获取指定对象
    /// </summary>
    /// <param name="_id"></param>
    /// <param name="_type"></param>
    /// <returns></returns>
    public static BaseGameEnity GetEnity(int _id,Enity _type)
    {
        switch (_type)
        {
            case Enity.fsm:
                
                if (allFiniteStateMachine[_id] != null)
                {
                    return (BaseGameEnity)allFiniteStateMachine[_id];
                }
                else
                {
                    Debug.Log("[warn]状态机 抓取对象失败");
                    return null;
                }

            case Enity.telegram:
                if (allMessageEvent[_id] != null)
                {
                    return (BaseGameEnity)allMessageEvent[_id];
                }
                else
                {
                    Debug.Log("[warn]消息 抓取对象失败");
                    return null;
                }

            case Enity.broadcast:
                if (allBroadcastEvent[_id] != null)
                {
                    return (BaseGameEnity)allBroadcastEvent[_id];
                }
                else
                {
                    Debug.Log("[warn]广播 抓取对象失败");
                    return null;
                }
            default:
                Debug.Log("【warn】不存在指定类型对象");
                return null;
        }
    }

    /// <summary>
    /// 状态机更新
    /// </summary>
    private void FsmUpdate()
    {   
        /*
        foreach (FiniteStateMachine fsm in allFiniteStateMachine.Values)
        {
            fsm.UpdateFsm();
        }
        */
        for (int i = 0; i < allFiniteStateMachine.Count; i++)
        {
            allFiniteStateMachine[i].UpdateFsm();
        }
    }

    /// <summary>
    /// 消息 更新
    /// </summary>
    /// <param name="_currentTime"></param>
    private void MessageUpdate(double _currentTime)
    {
        //Debug.Log(allMessageEvent.Count.ToString());
        /*
        foreach (TimeUtil message in allMessageEvent.current_.Values)
        {
            message.UpdateForMessage(_currentTime);
        }
        */
        for (int i = 0; i < allMessageEvent.Count; i++)
        {
            allMessageEvent[i].UpdateForMessage(_currentTime);
        }
    }

    /// <summary>
    /// 广播更新
    /// </summary>
    /// <param name="_currentTime"></param>
    private void BroadcastUpdate(double _currentTime)
    {
        /*
        foreach (TimeUtil broadcast in allBroadcastEvent.Values)
        {
            broadcast.UpdateForBroadcast(_currentTime);
        }
        */

        for (int i = 0; i < allBroadcastEvent.Count; i++)
        {
            allBroadcastEvent[i].UpdateForBroadcast(_currentTime);
        }
    }


    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        double currentTime = EditorApplication.timeSinceStartup;
        MessageUpdate(currentTime);
        BroadcastUpdate(currentTime);


        FsmUpdate();

        // 双缓冲 交换Data
        /*allFiniteStateMachine.Swap();
        allMessageEvent.Swap();
        allBroadcastEvent.Swap();
        */
    }

}




public class ChangeableDictionary
{
    // 类型
    public Enity enity_;
    // 当前表
    public Dictionary<int, object> current_;
    // 缓冲表
    public Dictionary<int, object> next_;

    public ChangeableDictionary(Enity _enity)
    {
        this.enity_ = _enity;
        this.current_ = new Dictionary<int, object>();
        this.next_ = new Dictionary<int, object>();
    }

    public void Add(int _key,object _value)
    {
        this.next_.Add(_key, _value);
    }

    public void Reset()
    {
        foreach (int _id in this.current_.Keys)
        {
            this.current_.Remove(_id);
        }
    }

    public void Swap()
    {
        //Dictionary<int, object> temp = this.current_;
        this.current_ = this.next_;
        //this.next_ = temp;
    }

   
}
