using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static GlobalData;

public class TimeUtil : BaseGameEnity
{
    // id
    public int id_;
    // ������
    public int sender_;
    // ������
    public int receiver_;
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
    // ���� ί�� �¼�����
    public delegate void Todo(params object[] elements_);
    // ί���ֶ�
    public Todo todo_;

    /// <summary>
    /// ѭ����Ϣ ��Ϣ������
    /// </summary>
    /// <param name="_sender">������</param>
    /// <param name="_receiver">������</param>
    /// <param name="_delayTime">�ӳ�ʱ��</param>
    /// <param name="_loopClaps">ѭ�����</param>
    /// <param name="_todo">��������</param>
    /// <param name="_elements">������������Ĳ���</param>
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

        // ʵ�ֽӿ�ע��
        //this.RegisterEnity(Enity.telegram, this);
    }
    /// <summary>
    /// ������Ϣ
    /// </summary>
    /// <param name="_sender">������</param>
    /// <param name="_receiver">������</param>
    /// <param name="_delayTime">�ӳ�ʱ��</param>
    /// <param name="_todo">��������</param>
    /// <param name="_elements">������������Ĳ���</param>
    public TimeUtil(int _sender, int _receiver, double _delayTime, Todo _todo, params object[] _elements) : base(telegramId_, Enity.telegram)
    {
        this.sender_ = _sender;
        this.receiver_ = _receiver;
        this.beginTime_ = EditorApplication.timeSinceStartup;
        this.delayTime_ = _delayTime;
        this.isLoop_ = false;
        this.todo_ = _todo;
        this.elements_ = _elements;

        // ʵ�ֽӿ�ע��
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
