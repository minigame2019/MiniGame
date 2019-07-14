using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;


public class AddViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform viewContainer = new GameObject("Game Views").transform;
    readonly GameContext gameContext;
    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Cube);
        //return context.CreateCollector(GameMatcher.Sprite);
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCube && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            go.transform.SetParent(viewContainer, false);
            e.AddView(go);
            go.Link(e);
        }
    }
}
