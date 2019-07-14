using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem, ICleanupSystem
{
    readonly IGroup<GameEntity> moves;
    readonly IGroup<GameEntity> moveCompletes;
    const float speed = 4f;

    public MoveSystem(Contexts contexts)
    {
        moves = contexts.game.GetGroup(GameMatcher.Move);
        moveCompletes = contexts.game.GetGroup(GameMatcher.MoveComplete);
    }

    public void Execute()
    {
        foreach (GameEntity e in moves.GetEntities())
        {
            Debug.Log("Move");
            Debug.Log(e.move.target);
            Debug.Log(e.position.value);

            Vector3 dir = e.move.target - e.position.value;
            Debug.Log(dir);
            Vector3 newPosition = e.position.value + dir.normalized * speed * Time.deltaTime;
            e.ReplacePosition(newPosition);
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //e.ReplaceDirection(angle);

            float dist = dir.magnitude;
            if (dist <= 0.5f)
            {
                e.RemoveMove();
                e.isMoveComplete = true;
            }
        }
    }

    public void Cleanup()
    {
        foreach (GameEntity e in moveCompletes.GetEntities())
        {
            e.isMoveComplete = false;
        }
    }
}