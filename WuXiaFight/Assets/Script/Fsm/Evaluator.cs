    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Evaluator 
{
    public string name_;

    public Evaluator(string _name)
    {
        this.name_ = _name;
    }

    public virtual bool GetTrigger()
    {
        return true;
    }
    
}
