
public class Services
{
    public readonly ILogService Log;
    public readonly ICameraService Camera;


    public Services(ILogService log,ICameraService camera)
    {
        Log = log;
        Camera = camera;
    }

}