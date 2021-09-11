using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static GlobalData;

public class TimeUtil : BaseGameEnity
{
    // 发送者
    public int sender_;
    // 发送者类型
    public Enity senderType_;

    // 接收者
    public int receiver_;
    // 接收者类型
    public Enity receiverType_;

    // 事件注入时间
    public double beginTime_;
    // 延迟时间
    public double delayTime_;
    // 是否循环
    public bool isLoop_;
    // 循环间隙
    public double loopClaps_;
    // 附带参数列表
    public object[] elements_;
    // 委托字段
    public Todo todo_;

    /// <summary>
    /// 循环消息 消息包生成
    /// </summary>
    /// <param name="_sender">发送者</param>
    /// <param name="_receiver">接收者</param>
    /// <param name="_delayTime">延迟时间</param>
    /// <param name="_loopClaps">循环间隔</param>
    /// <param name="_elements">匿名方法所需的参数</param>
    public TimeUtil(int _sender,Enity _senderType,int _receiver,Enity _receiverType,double _delayTime,double _loopClaps, Todo _todo,params object[] _elements):base(telegramId_,Enity.telegram)
    {
        this.sender_ = _sender;
        this.senderType_ = _senderType;
        this.receiver_ = _receiver;
        this.receiverType_ = _receiverType;

        this.beginTime_ = EditorApplication.timeSinceStartup;
        this.delayTime_ = _delayTime;
        this.isLoop_ = true;
        this.loopClaps_ = _loopClaps;
        this.todo_ = _todo;
        this.elements_ = _elements;

        // 实现接口注册(转移至父类接口处理)
        //this.RegisterEnity(Enity.telegram, this);
    }

    /// <summary>
    /// 单次消息
    /// </summary>
    /// <param name="_sender">发送者</param>
    /// <param name="_receiver">接收者</param>
    /// <param name="_delayTime">延迟时间</param>
    /// <param name="_elements">匿名方法所需的参数</param>
    public TimeUtil(int _sender, Enity _senderType, int _receiver, Enity _receiverType, double _delayTime, Todo _todo, params object[] _elements) : base(telegramId_, Enity.telegram)
    {
        this.sender_ = _sender;
        this.senderType_ = _senderType;
        this.receiver_ = _receiver;
        this.receiverType_ = _receiverType;

        this.beginTime_ = EditorApplication.timeSinceStartup;
        this.delayTime_ = _delayTime;
        this.isLoop_ = false;
        this.todo_ = _todo;
        this.elements_ = _elements;

        // 实现接口注册(转移至父类接口处理)
        //this.RegisterEnity(Enity.telegram, this);
    }

    /// <summary>
    /// 循环广播 广播包生成
    /// </summary>
    /// <param name="_sender"></param>
    /// <param name="_delayTime"></param>
    /// <param name="_loopClaps"></param>
    /// <param name="_todo"></param>
    /// <param name="_elements"></param>
    public TimeUtil(int _sender, Enity _senderType,double _delayTime, double _loopClaps, Todo _todo, params object[] _elements):base(broadcastId_,Enity.broadcast)
    {
        this.sender_ = _sender;
        this.senderType_ = _senderType;
        this.beginTime_ = EditorApplication.timeSinceStartup;
        this.delayTime_ = _delayTime;
        this.isLoop_ = true;
        this.loopClaps_ = _loopClaps;
        this.todo_ = _todo;
        this.elements_ = _elements;
    }

    /// <summary>
    /// 单次广播 广播包生成
    /// </summary>
    /// <param name="_sender"></param>
    /// <param name="_delayTime"></param>
    /// <param name="_todo"></param>
    /// <param name="_elements"></param>
    public TimeUtil(int _sender, Enity _senderType, double _delayTime, Todo _todo ,params object[] _elements) : base(broadcastId_, Enity.broadcast)
    {
        this.sender_ = _sender;
        this.senderType_ = _senderType;
        this.beginTime_ = EditorApplication.timeSinceStartup;
        this.delayTime_ = _delayTime;
        this.isLoop_ = false;
        this.todo_ = _todo;
        this.elements_ = _elements;

        // 实现接口注册(转移至父类接口处理)
        //this.RegisterEnity(Enity.telegram, this);
    }

    /// <summary>
    /// 新增消息 
    /// </summary>
    /// <param name="_sender"></param>
    /// <param name="_receiver"></param>
    /// <param name="_delayTime"></param>
    /// <param name="_elements"></param>
    public static TimeUtil AddMessageEvent(int _sender, Enity _senderType,int _receiver, Enity _receiverType,double _delayTime, Todo _todo, params object[] _elements)
    {
        TimeUtil t = new TimeUtil(_sender, _senderType, _receiver, _receiverType, _delayTime,_todo,_elements);
        return t;
    }

    /// <summary>
    /// 新增循环消息
    /// </summary>
    /// <param name="_sender"></param>
    /// <param name="_receiver"></param>
    /// <param name="_delayTime"></param>
    /// <param name="_loopClaps"></param>
    /// <param name="_elements"></param>
    public static TimeUtil AddLoopMessageEvent(int _sender, Enity _senderType, int _receiver, Enity _receiverType,double _delayTime, double _loopClaps, Todo _todo,params object[] _elements)
    {
        TimeUtil t = new TimeUtil(_sender, _senderType,_receiver, _receiverType, _delayTime, _loopClaps, _todo, _elements);
        return t;
    }

    /// <summary>
    /// 新增广播
    /// </summary>
    /// <param name="_sender"></param>
    /// <param name="_delayTime"></param>
    /// <param name="_todo"></param>
    /// <param name="_elements"></param>
    public static TimeUtil AddBroadcastEvent(int _sender, Enity _senderType, double _delayTime, Todo _todo, params object[] _elements)
    {
        TimeUtil t = new TimeUtil(_sender,_senderType,_delayTime,_todo,_elements);
        return t;
    }

    /// <summary>
    /// 新增循环广播
    /// </summary>
    /// <param name="_sender"></param>
    /// <param name="_delayTime"></param>
    /// <param name="_loopClaps"></param>
    /// <param name="_todo"></param>
    /// <param name="_elements"></param>
    public static TimeUtil AddLoopBroadcastEvent(int _sender, Enity _senderType, double _delayTime, double _loopClaps, Todo _todo, params object[] _elements)
    {
        TimeUtil t = new TimeUtil(_sender, _senderType,_delayTime, _loopClaps,_todo,_elements);
        return t;
    }

    public void UpdateForMessage(double _currentTime)
    {
        if (this.beginTime_ + this.delayTime_ <= _currentTime)
        {
            //BaseGameEnity receiver = GetEnity(this.receiver_, this.receiverType_);
            //receiver.MessageHandler(this.todo_, elements_);
            this.todo_(elements_);
            if (!this.isLoop_)
            {
                // 若不在循环里，则清除
                allMessageEvent.Remove(this.id_);
            }
        }
    }

    public void UpdateForBroadcast(double _currentTime)
    {
        if (this.beginTime_ + this.delayTime_ <= _currentTime)
        {
            this.todo_(this.elements_);
            if (!this.isLoop_)
            {
                // 若不在循环里，则清除
                allBroadcastEvent.Remove(this.id_);
            }
        }
    }

}
