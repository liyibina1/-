using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static GlobalData;

public class GlobalData : MonoBehaviour
{

    // ʵ������ö��
    // ״̬�� ��Ϣ �㲥
    public enum Enity{ fsm,telegram,broadcast};
    // ��Ϣ �¼�ö��
    public enum messageEvent { changeState,};


    // ״̬�����к�
    public static int fsmId_ = 0;
    // ��Ϣ���к�
    public static int telegramId_ = 0;
    // �㲥���к�
    public static int broadcastId_ = 0;

    // ���� ί�� �¼�����
    public delegate void Todo(params object[] elements_);

    // ���ɵ�����״̬��
    //public static ChangeableDictionary allFiniteStateMachine = new ChangeableDictionary(Enity.fsm);
    public static Dictionary<int, FiniteStateMachine> allFiniteStateMachine = new Dictionary<int, FiniteStateMachine>();
    // ���ɵ�������Ϣ�¼�
    //public static ChangeableDictionary allMessageEvent = new ChangeableDictionary(Enity.telegram);
    public static Dictionary<int, TimeUtil> allMessageEvent = new Dictionary<int, TimeUtil>();
    // ���ɵ����й㲥�¼�
    //public static ChangeableDictionary allBroadcastEvent = new ChangeableDictionary(Enity.broadcast);
    public static Dictionary<int, TimeUtil> allBroadcastEvent = new Dictionary<int, TimeUtil>();
    /// <summary>
    /// ����id��ȡָ������
    /// </summary>
    /// <param name="_id"></param>
    /// <param name="_type"></param>
    /// <returns></returns>
    public static BaseGameEnity GetEnity(int _id,Enity _type)
    {
        switch (_type)
        {
            case Enity.fsm:
                
                if (allFiniteStateMachine[_id] != null)
                {
                    return (BaseGameEnity)allFiniteStateMachine[_id];
                }
                else
                {
                    Debug.Log("[warn]״̬�� ץȡ����ʧ��");
                    return null;
                }

            case Enity.telegram:
                if (allMessageEvent[_id] != null)
                {
                    return (BaseGameEnity)allMessageEvent[_id];
                }
                else
                {
                    Debug.Log("[warn]��Ϣ ץȡ����ʧ��");
                    return null;
                }

            case Enity.broadcast:
                if (allBroadcastEvent[_id] != null)
                {
                    return (BaseGameEnity)allBroadcastEvent[_id];
                }
                else
                {
                    Debug.Log("[warn]�㲥 ץȡ����ʧ��");
                    return null;
                }
            default:
                Debug.Log("��warn��������ָ�����Ͷ���");
                return null;
        }
    }

    /// <summary>
    /// ״̬������
    /// </summary>
    private void FsmUpdate()
    {   
        /*
        foreach (FiniteStateMachine fsm in allFiniteStateMachine.Values)
        {
            fsm.UpdateFsm();
        }
        */
        for (int i = 0; i < allFiniteStateMachine.Count; i++)
        {
            allFiniteStateMachine[i].UpdateFsm();
        }
    }

    /// <summary>
    /// ��Ϣ ����
    /// </summary>
    /// <param name="_currentTime"></param>
    private void MessageUpdate(double _currentTime)
    {
        //Debug.Log(allMessageEvent.Count.ToString());
        /*
        foreach (TimeUtil message in allMessageEvent.current_.Values)
        {
            message.UpdateForMessage(_currentTime);
        }
        */
        for (int i = 0; i < allMessageEvent.Count; i++)
        {
            allMessageEvent[i].UpdateForMessage(_currentTime);
        }
    }

    /// <summary>
    /// �㲥����
    /// </summary>
    /// <param name="_currentTime"></param>
    private void BroadcastUpdate(double _currentTime)
    {
        /*
        foreach (TimeUtil broadcast in allBroadcastEvent.Values)
        {
            broadcast.UpdateForBroadcast(_currentTime);
        }
        */

        for (int i = 0; i < allBroadcastEvent.Count; i++)
        {
            allBroadcastEvent[i].UpdateForBroadcast(_currentTime);
        }
    }


    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        double currentTime = EditorApplication.timeSinceStartup;
        MessageUpdate(currentTime);
        BroadcastUpdate(currentTime);


        FsmUpdate();

        // ˫���� ����Data
        /*allFiniteStateMachine.Swap();
        allMessageEvent.Swap();
        allBroadcastEvent.Swap();
        */
    }

}




public class ChangeableDictionary
{
    // ����
    public Enity enity_;
    // ��ǰ��
    public Dictionary<int, object> current_;
    // �����
    public Dictionary<int, object> next_;

    public ChangeableDictionary(Enity _enity)
    {
        this.enity_ = _enity;
        this.current_ = new Dictionary<int, object>();
        this.next_ = new Dictionary<int, object>();
    }

    public void Add(int _key,object _value)
    {
        this.next_.Add(_key, _value);
    }

    public void Reset()
    {
        foreach (int _id in this.current_.Keys)
        {
            this.current_.Remove(_id);
        }
    }

    public void Swap()
    {
        //Dictionary<int, object> temp = this.current_;
        this.current_ = this.next_;
        //this.next_ = temp;
    }

   
}
