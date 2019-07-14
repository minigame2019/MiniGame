using UnityEngine;
using System.Collections.Generic;
using Entitas;
using UnityEngine.UI;
using System.Collections;
public class RenderCubeSystem : ReactiveSystem<GameEntity>
{
    public RenderCubeSystem(Contexts contexts) : base(contexts.game)
    {
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Cube);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCube && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            GameObject go = e.view.gameObject;
           
            // TODO: 
            // render 

        }
    }

}
