using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

        if (yInput == 0 || yInput < 0)
        {
            rb.gravityScale = player.defaultGravity;
        }
        else if (yInput > 0)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
        }

        if (xInput != 0 && yInput == 0)
        {
            stateMachine.ChangeState(player.airState);
        }

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
