    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class FiniteStateMachine
{
    // 名字
    public string name_;
    // 当前状态机状态
    public string status_;
    // 状态机下包含状态的数组
    public Dictionary<string,State> state_;
    // 当前运行的状态
    public State currentState_;
    // 全局状态
    public State globalState_;
    // 上一个转入的状态
    public State previousState_;
    // 动画状态机
    public Animator animation_;

    // 存储创建的状态机
    public Dictionary<string, FiniteStateMachine> allFiniteStateMachine;
    

    /// 等待创建 发布-订阅者模式

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="_id">状态机唯一key</param>
    /// <param name="_name">状态机名字</param>
    /// <param name="_state">状态机包含的状态数组</param>
    /// <param name="_currentState">当前运行的状态</param>
    /// <param name="_globalState">全局状态</param>
    /// <param name="_animation">动画状态机</param>
    public FiniteStateMachine( string _name,  State _currentState,  State _globalState,  Animator _animation)
    {
        this.name_ = _name;
        Dictionary<string, State> _state = new Dictionary<string, State>();
        this.state_ = _state;
        this.currentState_ = _currentState;
        this.globalState_ = _globalState;
        this.animation_ = _animation;

        //allFiniteStateMachine.Add(this.name_, this);
        Debug.Log("创建FSM" + name_);
    }

    /// <summary>
    /// 状态机增加状态函数
    /// </summary>
    /// <param name="addState">要增加的状态</param>
    public void AddState(State _addState)
    {
        this.state_.Add(_addState.name_, _addState);
        Debug.Log(this.name_ + "成功增加状态" + _addState.name_);
    }

    /// <summary>
    /// 改变当前状态
    /// </summary>
    /// <param name="_changeState"></param>
    public void ChangeState(State _changeState)
    {
        /// 执行退出方法
        this.currentState_.OnStateExit();
        /// 执行进入方法
        _changeState.OnStateEnter();

        this.previousState_ = this.currentState_;
        this.currentState_ = _changeState;
    }

    /// <summary>
    /// 状态机遍历切换条件
    /// </summary>
    public void UpdateFsm()
    {   
        /// 全局状态存在且当前不处于全局状态时，判断是否可以进入全局状态
        if ((this.globalState_ != null) && (this.currentState_ != this.globalState_) && (this.globalState_.GetGlobalStateTrigger()))
        {
            this.ChangeState(this.globalState_);
        }


        if (this.currentState_.UpdateStateForChange() != null)
        {   
            this.ChangeState(this.currentState_.UpdateStateForChange());
        }

        this.currentState_.OnStateUpdate();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FiniteStateMachine fsm in allFiniteStateMachine.Values)
        {
            fsm.UpdateFsm();
        }
    }

}

