using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1GroundedState : EnemyState
{
    protected Enemy1 enemy;
    protected Transform player;
    public Enemy1GroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy1 _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        //player = PlayerManager.instance.player.transform;
    }

    public override void Update()
    {
        base.Update();

        // if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 2)
        // {
        //     stateMachine.ChangeState(enemy.battleState);
        // }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
