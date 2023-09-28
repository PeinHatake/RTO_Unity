using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    #region States
    public Enemy1IdleState idleState { get; private set; }
    public Enemy1MoveState moveState { get; private set; }

    #endregion
    protected override void Awake()
    {
        base.Awake();

        idleState = new Enemy1IdleState(this, stateMachine, "Idle", this);
        moveState = new Enemy1MoveState(this, stateMachine, "Move", this);

    }
        protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

}
