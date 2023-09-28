using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1MoveState : Enemy1GroundedState
{
    private float distance;
    private int index;
    public Enemy1MoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy1 _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.currentLocation = enemy.rb.position;
        distance = Mathf.Abs(enemy.currentLocation.x - enemy.defaultLocation.x);

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);
        if (distance > enemy.distanceToMove)
        {
            enemy.defaultLocation = enemy.rb.position;
            distance = 0;
            enemy.Flip();
        }
    }
}
