using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalData;

    public class PlayerFsm : MonoBehaviour
    {
    private static string playerFsmName = "playerFsm";

    public FiniteStateMachine fsm;
    
    //enum PlayerState { Move,Idle,Jump};

    // Start is called before the first frame update
    void Start()
    {   

        IdleState idleState = new IdleState(); 
        MoveState moveState = new MoveState();
        JumpState jumpState = new JumpState();


        IdleToMove idleToMove = new IdleToMove();
        MoveToJump moveToJump = new MoveToJump();
        JumpToIdle jumpToIdle = new JumpToIdle();

        Transition idleToMoveTran = new Transition(moveState, idleToMove);
        Transition moveToJumpTran = new Transition(jumpState, moveToJump);
        Transition jumpToIdleTran = new Transition(idleState, jumpToIdle);

        idleState.AddTransition(idleToMoveTran);
        moveState.AddTransition(moveToJumpTran);
        jumpState.AddTransition(jumpToIdleTran);

        FiniteStateMachine playerFsm = new FiniteStateMachine(playerFsmName,idleState,null,null);
        //playerFsm.RegisterEnity(Enity.fsm, playerFsm);

        playerFsm.AddState(idleState);
        playerFsm.AddState(moveState);
        playerFsm.AddState(jumpState);

        fsm = playerFsm;
    }

    // Update is called once per frame
    void Update()
    {
        //fsm.UpdateFsm();
    }


    class IdleState : State
    {
        public IdleState() : base("Idle", playerFsmName)
        {

        }

        public override void OnStateEnter()
        {
            Debug.Log("Enter" + this.name_);
        }

        public override void OnStateUpdate()
        {
            Debug.Log("Update" + this.name_);
        }

        public override void OnStateExit()
        {
            Debug.Log("Exit" + this.name_);
        }
    }

    class MoveState : State
    {
        public MoveState() : base("Move", playerFsmName)
        {

        }

        public override void OnStateEnter()
        {
            Debug.Log("Enter" + this.name_);
        }

        public override void OnStateUpdate()
        {
            Debug.Log("Update" + this.name_);
        }

        public override void OnStateExit()
        {
            Debug.Log("Exit" + this.name_);
        }
    }

    class JumpState : State
    {
        public JumpState() : base("Jump", playerFsmName)
        {

        }

        public override void OnStateEnter()
        {
            Debug.Log("Enter" + this.name_);
        }

        public override void OnStateUpdate()
        {
            Debug.Log("Update" + this.name_);
        }

        public override void OnStateExit()
        {
            Debug.Log("Exit" + this.name_);
        }
    }

    class IdleToMove : Evaluator
    {
        public bool idleToMove = true;
        public IdleToMove() : base("IdleToMove")
        {

        }

        public override bool GetTrigger()
        {
            return idleToMove;
        }
    }

    class MoveToJump : Evaluator
    {
        public bool moveToJump = true;
        public MoveToJump() : base("MoveToJump")
        {

        }

        public override bool GetTrigger()
        {
            return moveToJump;
        }
    }

    class JumpToIdle : Evaluator
    {
        public bool jumpToIdle = false;
        public JumpToIdle() : base("JumpToIdle")
        {

        }

        public override bool GetTrigger()
        {
            return jumpToIdle;
        }
    }
    }

