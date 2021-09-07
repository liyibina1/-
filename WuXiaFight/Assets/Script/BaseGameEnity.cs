using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalData;


interface IRegisterEnity
{
    void RegisterEnity(Enity _type,object _object);
}
public class BaseGameEnity :IRegisterEnity
{
    // key
    public int id_;
    // 实体类型
    public Enity type_;


    public BaseGameEnity(int _id,Enity _type)
    {
        this.id_ = _id;
        this.type_ = _type;

        //Debug.Log(this);
        this.RegisterEnity(_type, this);
        
    }

    public void RegisterEnity(Enity _type, object _object)
    {
        switch (_type)
        {
            case Enity.fsm:
                fsmId_ += 1;
                Debug.Log(_object);
                Debug.Log(fsmId_);
                Debug.Log((FiniteStateMachine)_object);
                allFiniteStateMachine.Add(fsmId_, (FiniteStateMachine)_object);
                break;

            case Enity.telegram:
                telegramId_ += 1;
                allMessageEvent.Add(telegramId_, (TimeUtil)_object);
                break;

            case Enity.broadcast:
                broadcastId_ += 1;
                allBroadcastEvent.Add(broadcastId_, (TimeUtil)_object);
                break;

            default:
                Debug.Log("【warn】生成实体ID未命中");
                break;
        }
    }

    /// <summary>
    /// 用于派生类重写
    /// </summary>
    /// <returns></returns>
    public virtual bool MessageHandler()
    {
        return true;
    }

}
