using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.gravityScale = 0;
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(xInput * player.moveSpeed, yInput);

        if ((xInput == 0 && !player.IsGroundDetected()) || yInput != 0)
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }


    }

    public override void Exit()
    {
        base.Exit();

    }
}
