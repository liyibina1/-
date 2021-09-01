using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    // key
    public int id_;
    // 名字
    public string name_;
    // 当前状态机状态
    public string status_;
    // 状态机下包含状态的数组
    public State[] state_;
    // 当前运行的状态
    public State currentState_;
    // 全局状态
    public State globalState_;
    // 上一个转入的状态
    public State previousState_;
    // 动画状态机
    public Animator animation_;
    // 存储创建的状态机
    public FiniteStateMachine[] allFiniteStateMachine;

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
    public FiniteStateMachine(int _id, string _name, State[] _state, State _currentState, State _globalState, Animator _animation)
    {
        _id += 1;
        this.id_ = _id;
        this.name_ = _name;
        this.state_ = _state;
        this.currentState_ = _currentState;
        this.globalState_ = _globalState;
        this.animation_ = _animation;

        allFiniteStateMachine[_id] = this;

        Debug.Log("创建FSM" + name_);
    }

    /// <summary>
    /// 状态机增加状态函数
    /// </summary>
    /// <param name="addState">要增加的状态</param>
    public void AddState(State _addState)
    {
        this.state_[this.state_.Length] = _addState;
        Debug.Log(this.name_ + "成功增加状态" + _addState.name_);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}

