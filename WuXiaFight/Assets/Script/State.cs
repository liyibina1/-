using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // ״̬Ψһkey
    public int id_;
    // ״̬��
    public string name_;
    // ����״̬��Id
    public int fsmId_;
    // �л���������
    public Transition[] transition_;

    // ״̬����
    public FiniteStateMachine fsmMgr;

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="_id">״̬Ψһkey</param>
    /// <param name="_name">״̬��</param>
    /// <param name="_fsmId">����״̬��key</param>
    /// <param name="_transition">�л���������</param>
    public State(int _id, string _name, int _fsmId, Transition[] _transition)
    {
        this.id_ = _id;
        this.name_ = _name;
        this.fsmId_ = _fsmId;
        this.transition_ = _transition;

        if (fsmMgr.allFiniteStateMachine[fsmId_] == null)
        {
            Debug.Log("״̬��������");
            return;
        }

        fsmMgr.allFiniteStateMachine[fsmId_].AddState(this);

        Debug.Log(_name + "״̬�����ɹ�");
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
