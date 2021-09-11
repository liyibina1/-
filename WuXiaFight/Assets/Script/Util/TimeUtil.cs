using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static GlobalData;

public class TimeUtil : BaseGameEnity
{
    // ������
    public int sender_;
    // ����������
    public Enity senderType_;

    // ������
    public int receiver_;
    // ����������
    public Enity receiverType_;

    // �¼�ע��ʱ��
    public double beginTime_;
    // �ӳ�ʱ��
    public double delayTime_;
    // �Ƿ�ѭ��
    public bool isLoop_;
    // ѭ����϶
    public double loopClaps_;
    // ���������б�
    public object[] elements_;
    // ί���ֶ�
    public Todo todo_;

    /// <summary>
    /// ѭ����Ϣ ��Ϣ������
    /// </summary>
    /// <param name="_sender">������</param>
    /// <param name="_receiver">������</param>
    /// <param name="_delayTime">�ӳ�ʱ��</param>
    /// <param name="_loopClaps">ѭ�����</param>
    /// <param name="_elements">������������Ĳ���</param>
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

        // ʵ�ֽӿ�ע��(ת��������ӿڴ���)
        //this.RegisterEnity(Enity.telegram, this);
    }

    /// <summary>
    /// ������Ϣ
    /// </summary>
    /// <param name="_sender">������</param>
    /// <param name="_receiver">������</param>
    /// <param name="_delayTime">�ӳ�ʱ��</param>
    /// <param name="_elements">������������Ĳ���</param>
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

        // ʵ�ֽӿ�ע��(ת��������ӿڴ���)
        //this.RegisterEnity(Enity.telegram, this);
    }

    /// <summary>
    /// ѭ���㲥 �㲥������
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
    /// ���ι㲥 �㲥������
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

        // ʵ�ֽӿ�ע��(ת��������ӿڴ���)
        //this.RegisterEnity(Enity.telegram, this);
    }

    /// <summary>
    /// ������Ϣ 
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
    /// ����ѭ����Ϣ
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
    /// �����㲥
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
    /// ����ѭ���㲥
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
                // ������ѭ��������
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
                // ������ѭ��������
                allBroadcastEvent.Remove(this.id_);
            }
        }
    }

}
