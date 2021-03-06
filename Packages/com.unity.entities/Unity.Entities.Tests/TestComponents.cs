using Unity.Entities;

namespace Unity.Entities.Tests
{
	public struct EcsTestData : IComponentData
	{
		public int value;

		public EcsTestData(int inValue) { value = inValue; }
	}


    public struct EcsTestData2 : IComponentData
    {
        public int value0;
        public int value1;

        public EcsTestData2(int inValue) { value1 = value0 = inValue; }
    }

    public struct EcsTestData3 : IComponentData
    {
        public int value0;
        public int value1;
        public int value2;

        public EcsTestData3(int inValue) { value2 = value1 = value0 = inValue; }
    }

    public struct EcsTestData4 : IComponentData
    {
        public int value0;
        public int value1;
        public int value2;
        public int value3;

        public EcsTestData4(int inValue) { value3 = value2 = value1 = value0 = inValue; }
    }

    public struct EcsTestSharedComp : ISharedComponentData
    {
        public int value;

        public EcsTestSharedComp(int inValue) { value = inValue; }
    }

    public struct EcsTestSharedComp2 : ISharedComponentData
    {
        public int value0;
        public int value1;

        public EcsTestSharedComp2(int inValue) { value0 = value1 = inValue; }
    }
}
