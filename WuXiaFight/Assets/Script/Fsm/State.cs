    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class State
{
    // ״̬��
    public string name_;
    // ����״̬��Id
    public string fsmId_;
    // �л������ֵ�
    public Dictionary<int,Transition> transition_;

    // ״̬����
    public FiniteStateMachine fsmMgr;

    // �������˳��
    public int index_ = 0;
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="_id">״̬Ψһkey</param>
    /// <param name="_name">״̬��</param>
    /// <param name="_fsmId">����״̬��key</param>
    /// <param name="_transition">�л���������</param>
    public State( string _name, string _fsmId)
    {
        //this.id_ = _id;
        this.name_ = _name;
        this.fsmId_ = _fsmId;
        
        Dictionary<int, Transition> transition = new Dictionary<int, Transition>();
        this.transition_ = transition;

        /*
        if (fsmMgr.allFiniteStateMachine[name_] == null)
        {
            Debug.Log("״̬��������");
            return;
        }
        */
        //fsmMgr.allFiniteStateMachine[fsmId_].AddState(ref State);

        Debug.Log(_name + "״̬�����ɹ�");
    }

    // ����״̬������д
    // �����״̬ǰִ��
    public virtual void OnStateEnter()
    {
      
    }

    // ����״̬������д
    public virtual void OnStateUpdate() 
    {

    }

    // ����״̬������д
    public virtual void OnStateExit()
    {

    }

    public void AddTransition(Transition _transition)
    {
        //Debug.Log(this.index_.ToString());
        //Debug.Log(_transition.toState_.name_);
        //Debug.Log(this.name_);
        this.transition_.Add(this.index_,_transition);
        this.index_ += 1;
    }

    /// <summary>
    /// ������һ�����Խ����״̬�������򷵻�null
    /// </summary>
    /// <returns></returns>
    public State UpdateStateForChange()
    {
        foreach (Transition tran in this.transition_.Values)
        {
            if (tran.evaluator_.GetTrigger())
            {
                return tran.toState_;
            }
        }
        return null;
    }

    /// <summary>
    /// ȫ��״̬��д�����������Ƿ����ֱ�ӽ����״̬
    /// </summary>
    public virtual bool GetGlobalStateTrigger()
    {
        return false;
    }
    
}
