using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;

    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    private string animBoolName;


    protected float stateTimer;
    protected bool triggerCalled;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        rb = player.rb;
        player.anim.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

        //yInput = Input.GetAxisRaw("Vertical");
        //xInput = Input.GetAxisRaw("Horizontal");
        yInput = UltimateJoystick.GetVerticalAxis("Movement");
        xInput = UltimateJoystick.GetHorizontalAxis("Movement");

        player.anim.SetFloat("yVelocity", rb.velocity.y);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
