namespace Utility.Pull
{
    public interface IPull<TComponent> where TComponent : IPullObject
    {
        void Init(IPullContainer container);
        void Dispose();
        TComponent Get();
        void Put(TComponent component);
    }
}