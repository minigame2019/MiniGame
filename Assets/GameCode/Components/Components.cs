using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.UI;
[Game]
public class PositionComponent : IComponent
{
    public Vector3 value;
}

[Game]
public class DirectionComponent : IComponent
{
    public float value;
}

[Game]
public class ViewComponent : IComponent
{
    public GameObject gameObject;
    public IViewController instance;
}

[Game]
public class SpriteComponent : IComponent
{
    public string name;
}

[Game]
public class CubeComponent : IComponent
{
    public string name;
}

[Game]
public class MoverComponent : IComponent
{
}

[Game]
public class MoveComponent : IComponent
{
    public Vector3 target;
}

[Game]
public class MoveCompleteComponent : IComponent
{
}

[Input, Unique]
public class LeftMouseComponent : IComponent
{
}

[Input, Unique]
public class RightMouseComponent : IComponent
{
}

[Input]
public class MouseDownComponent : IComponent
{
    public Vector3 position;
}

[Input]
public class MousePositionComponent : IComponent
{
    public Vector3 position;
}

[Input]
public class MouseUpComponent : IComponent
{
    public Vector3 position;
}

