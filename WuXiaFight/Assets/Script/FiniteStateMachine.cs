using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    // key
    public int id_;
    // ����
    public string name_;
    // ��ǰ״̬��״̬
    public string status_;
    // ״̬���°���״̬������
    public State[] state_;
    // ��ǰ���е�״̬
    public State currentState_;
    // ȫ��״̬
    public State globalState_;
    // ��һ��ת���״̬
    public State previousState_;
    // ����״̬��
    public Animator animation_;
    // �洢������״̬��
    public FiniteStateMachine[] allFiniteStateMachine;

    /// �ȴ����� ����-������ģʽ

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="_id">״̬��Ψһkey</param>
    /// <param name="_name">״̬������</param>
    /// <param name="_state">״̬��������״̬����</param>
    /// <param name="_currentState">��ǰ���е�״̬</param>
    /// <param name="_globalState">ȫ��״̬</param>
    /// <param name="_animation">����״̬��</param>
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

        Debug.Log("����FSM" + name_);
    }

    /// <summary>
    /// ״̬������״̬����
    /// </summary>
    /// <param name="addState">Ҫ���ӵ�״̬</param>
    public void AddState(State _addState)
    {
        this.state_[this.state_.Length] = _addState;
        Debug.Log(this.name_ + "�ɹ�����״̬" + _addState.name_);
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

