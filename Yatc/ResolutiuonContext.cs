using System;

namespace Yatc
{
    public class ResolutiuonContext
    {
        public readonly ResolutiuonContext Parent;
        public readonly Type Type;

        public ResolutiuonContext(ResolutiuonContext parent, Type type)
        {
            Parent = parent;
            Type = type;
        }

        public bool LineageContains(Type type)
        {
            if (Type == type) return true;
            return Parent != null && Parent.LineageContains(type);
        }

        public ResolutiuonContext GetRoot()
        {
            return Parent == null ? this : Parent.GetRoot();
        }
    }
}