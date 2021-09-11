using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalData;

/// <summary>
/// 注册接口
/// </summary>
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
                
                //Debug.Log(_object);
                //Debug.Log(fsmId_);
                //Debug.Log((FiniteStateMachine)_object);
                allFiniteStateMachine.Add(fsmId_, (FiniteStateMachine)_object);
                fsmId_ += 1;
                break;

            case Enity.telegram:
                
                allMessageEvent.Add(telegramId_, (TimeUtil)_object);
                telegramId_ += 1;
                break;

            case Enity.broadcast:
                
                allBroadcastEvent.Add(broadcastId_, (TimeUtil)_object);
                broadcastId_ += 1;
                break;

            default:
                Debug.Log("【warn】生成实体ID未命中");
                break;
        }
    }

    /// <summary>
    /// 用于派生类重写消息接收
    /// </summary>
    /// <returns></returns>
    public virtual bool MessageHandler(Todo _todo,params object[] _elements)
    {
        _todo(_elements);
        Debug.Log("类型" + this.type_.ToString() + "Id" + this.id_.ToString() + "接收消息");
        return true;
    }

}
