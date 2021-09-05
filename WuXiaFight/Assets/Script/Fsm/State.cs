    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class State
{
    // 状态名
    public string name_;
    // 所在状态机Id
    public string fsmId_;
    // 切换条件字典
    public Dictionary<int,Transition> transition_;

    // 状态机类
    public FiniteStateMachine fsmMgr;

    // 标记条件顺序
    public int index_ = 0;
    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="_id">状态唯一key</param>
    /// <param name="_name">状态名</param>
    /// <param name="_fsmId">所在状态机key</param>
    /// <param name="_transition">切换条件数组</param>
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
            Debug.Log("状态机不存在");
            return;
        }
        */
        //fsmMgr.allFiniteStateMachine[fsmId_].AddState(ref State);

        Debug.Log(_name + "状态创建成功");
    }

    // 在子状态进行重写
    // 进入该状态前执行
    public virtual void OnStateEnter()
    {
      
    }

    // 在子状态进行重写
    public virtual void OnStateUpdate() 
    {

    }

    // 在子状态进行重写
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
    /// 返回下一个可以进入的状态，若无则返回null
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
    /// 全局状态重写函数，返回是否可以直接进入该状态
    /// </summary>
    public virtual bool GetGlobalStateTrigger()
    {
        return false;
    }
    
}
