//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity cameraServiceEntity { get { return GetGroup(MetaMatcher.CameraService).GetSingleEntity(); } }

    public bool isCameraService {
        get { return cameraServiceEntity != null; }
        set {
            var entity = cameraServiceEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isCameraService = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaEntity {

    static readonly CameraServiceComponent cameraServiceComponent = new CameraServiceComponent();

    public bool isCameraService {
        get { return HasComponent(MetaComponentsLookup.CameraService); }
        set {
            if (value != isCameraService) {
                var index = MetaComponentsLookup.CameraService;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : cameraServiceComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherCameraService;

    public static Entitas.IMatcher<MetaEntity> CameraService {
        get {
            if (_matcherCameraService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.CameraService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherCameraService = matcher;
            }

            return _matcherCameraService;
        }
    }
}
