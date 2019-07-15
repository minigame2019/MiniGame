using Entitas;

public class RegisterCameraSystem : IInitializeSystem
{
    public RegisterCameraSystem(Contexts contexts,ICameraService cameraService)
    {

    }

    public void Initialize()
    {

    }
}


public class RegisterLogSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly ILogService _logService;
    public RegisterLogSystem(Contexts contexts, ILogService cameraService)
    {

    }

    public void Initialize()
    {

    }
}

public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts,Services services) : base ("Services Registration Systems")
    {
        Add(new RegisterLogSystem(contexts, services.Log));
        Add(new RegisterCameraSystem(contexts, services.Camera));
    }
}