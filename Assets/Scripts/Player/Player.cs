using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public bool isBusy { get; private set; }


    [Header("Move Info")]
    public float moveSpeed = 12f;
    public float jumpForce;

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    
    [SerializeField]
    public Canvas inventory;
    #endregion

    public float defaultGravity;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Fly");
    }

    protected override void Start()
    {
        base.Start();
        defaultGravity = rb.gravityScale;
        stateMachine.Initialize(idleState);
        inventory.enabled = false;
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        if (Input.GetKeyDown(KeyCode.B))
        {
            inventory.enabled = !inventory.enabled;
        }

    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);

        isBusy = false;
    }



}
