using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    // 可以转到的状态
    public State toState_;
    // 求值器
    public Evaluator evaluator_;



    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="_toState">可以转到的状态</param>
    /// <param name="_evaluator">求值器</param>
    public Transition(State _toState, Evaluator _evaluator)
    {
        this.toState_ = _toState;
        this.evaluator_ = _evaluator;


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
