    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Transition 
{
    // ����ת����״̬
    public State toState_;
    // ��ֵ��
    public Evaluator evaluator_;



    /// <summary>
    /// ����
    /// </summary>
    /// <param name="_toState">����ת����״̬</param>
    /// <param name="_evaluator">��ֵ��</param>
    public Transition( State _toState, Evaluator _evaluator)
    {
        this.toState_ = _toState;
        this.evaluator_ = _evaluator;
    }

}
