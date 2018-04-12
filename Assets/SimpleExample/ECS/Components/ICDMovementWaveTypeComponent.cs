using System;
using Unity.Entities;

namespace SimpleExample.ECS
{
    [Serializable]
    public struct ICDMovementWaveType : IComponentData   
    {
        public int WaveType;
    }
    
    public class ICDMovementWaveTypeComponent : ComponentDataWrapper<ICDMovementWaveType>{}
}

