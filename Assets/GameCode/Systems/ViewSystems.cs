using Entitas;

public class ViewSystems : Feature
{
    public ViewSystems(Contexts contexts) : base("View Systems")
    {
        Add(new AddViewSystem(contexts));
        Add(new RenderCubeSystem(contexts));
        Add(new RenderPositionSystem(contexts));
        Add(new RenderDirectionSystem(contexts));
    }
}