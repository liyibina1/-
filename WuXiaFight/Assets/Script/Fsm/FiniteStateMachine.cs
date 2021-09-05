    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class FiniteStateMachine
{
    // ����
    public string name_;
    // ��ǰ״̬��״̬
    public string status_;
    // ״̬���°���״̬������
    public Dictionary<string,State> state_;
    // ��ǰ���е�״̬
    public State currentState_;
    // ȫ��״̬
    public State globalState_;
    // ��һ��ת���״̬
    public State previousState_;
    // ����״̬��
    public Animator animation_;

    // �洢������״̬��
    public Dictionary<string, FiniteStateMachine> allFiniteStateMachine;
    

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
    public FiniteStateMachine( string _name,  State _currentState,  State _globalState,  Animator _animation)
    {
        this.name_ = _name;
        Dictionary<string, State> _state = new Dictionary<string, State>();
        this.state_ = _state;
        this.currentState_ = _currentState;
        this.globalState_ = _globalState;
        this.animation_ = _animation;

        //allFiniteStateMachine.Add(this.name_, this);
        Debug.Log("����FSM" + name_);
    }

    /// <summary>
    /// ״̬������״̬����
    /// </summary>
    /// <param name="addState">Ҫ���ӵ�״̬</param>
    public void AddState(State _addState)
    {
        this.state_.Add(_addState.name_, _addState);
        Debug.Log(this.name_ + "�ɹ�����״̬" + _addState.name_);
    }

    /// <summary>
    /// �ı䵱ǰ״̬
    /// </summary>
    /// <param name="_changeState"></param>
    public void ChangeState(State _changeState)
    {
        /// ִ���˳�����
        this.currentState_.OnStateExit();
        /// ִ�н��뷽��
        _changeState.OnStateEnter();

        this.previousState_ = this.currentState_;
        this.currentState_ = _changeState;
    }

    /// <summary>
    /// ״̬�������л�����
    /// </summary>
    public void UpdateFsm()
    {   
        /// ȫ��״̬�����ҵ�ǰ������ȫ��״̬ʱ���ж��Ƿ���Խ���ȫ��״̬
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

