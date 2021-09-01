using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // 状态唯一key
    public int id_;
    // 状态名
    public string name_;
    // 所在状态机Id
    public int fsmId_;
    // 切换条件数组
    public Transition[] transition_;

    // 状态机类
    public FiniteStateMachine fsmMgr;

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="_id">状态唯一key</param>
    /// <param name="_name">状态名</param>
    /// <param name="_fsmId">所在状态机key</param>
    /// <param name="_transition">切换条件数组</param>
    public State(int _id, string _name, int _fsmId, Transition[] _transition)
    {
        this.id_ = _id;
        this.name_ = _name;
        this.fsmId_ = _fsmId;
        this.transition_ = _transition;

        if (fsmMgr.allFiniteStateMachine[fsmId_] == null)
        {
            Debug.Log("状态机不存在");
            return;
        }

        fsmMgr.allFiniteStateMachine[fsmId_].AddState(this);

        Debug.Log(_name + "状态创建成功");
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
