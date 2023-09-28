using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();


        if (!player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.jumpState);
        }

        if (yInput > 0 && player.IsGroundDetected())
        {
            rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
            stateMachine.ChangeState(player.jumpState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


}
