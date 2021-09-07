using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static GlobalData;

public class TimeUtil : BaseGameEnity
{
    // id
    public int id_;
    // 发送者
    public int sender_;
    // 接收者
    public int receiver_;
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
    // 声名 委托 事件函数
    public delegate void Todo(params object[] elements_);
    // 委托字段
    public Todo todo_;

    /// <summary>
    /// 循环消息 消息包生成
    /// </summary>
    /// <param name="_sender">发送者</param>
    /// <param name="_receiver">接收者</param>
    /// <param name="_delayTime">延迟时间</param>
    /// <param name="_loopClaps">循环间隔</param>
    /// <param name="_todo">匿名方法</param>
    /// <param name="_elements">匿名方法所需的参数</param>
    public TimeUtil(int _sender,int _receiver,double _delayTime,double _loopClaps, Todo _todo,params object[] _elements):base(telegramId_,Enity.telegram)
    {
        this.sender_ = _sender;
        this.receiver_ = _receiver;
        this.beginTime_ = EditorApplication.timeSinceStartup;
        this.delayTime_ = _delayTime;
        this.isLoop_ = true;
        this.loopClaps_ = _loopClaps;
        this.todo_ = _todo;
        this.elements_ = _elements;

        // 实现接口注册
        //this.RegisterEnity(Enity.telegram, this);
    }
    /// <summary>
    /// 单次消息
    /// </summary>
    /// <param name="_sender">发送者</param>
    /// <param name="_receiver">接收者</param>
    /// <param name="_delayTime">延迟时间</param>
    /// <param name="_todo">匿名方法</param>
    /// <param name="_elements">匿名方法所需的参数</param>
    public TimeUtil(int _sender, int _receiver, double _delayTime, Todo _todo, params object[] _elements) : base(telegramId_, Enity.telegram)
    {
        this.sender_ = _sender;
        this.receiver_ = _receiver;
        this.beginTime_ = EditorApplication.timeSinceStartup;
        this.delayTime_ = _delayTime;
        this.isLoop_ = false;
        this.todo_ = _todo;
        this.elements_ = _elements;

        // 实现接口注册
        //this.RegisterEnity(Enity.telegram, this);
    }


    /*public TimeUtil(int _sender, int _receiver, double _delayTime, double _loopClaps, Todo _todo, params object[] _elements):base()
    {
        this.id_ = RegisterEnity(Enity.telegram, this);
        this.sender_ = _sender;
        this.receiver_ = _receiver;
        this.beginTime_ = EditorApplication.timeSinceStartup;
        this.delayTime_ = _delayTime;
        this.isLoop_ = true;
        this.loopClaps_ = _loopClaps;
        this.todo_ = _todo;
        this.elements_ = _elements;
    }
    */


    public static void AddTimeEvent()
    {
        //TimeUtil t = new TimeUtil();
    }

    public static void AddLoopTimeEvent()
    {

    }

    public void UpdateForTimeUtil()
    {

    }

}
