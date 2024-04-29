using Pool;

namespace Unit.Client.Pool
{
    public class Pool : BasePool<InteractableElement>
    {
        protected override InteractableElement AddInstance()
        {
            var instance = Instantiate(prefab, parent);
            instance.SetObserver(interactableObserver);
            instance.Init();
            instance.ReturnInPool += (_) => ReturnInstance(instance);
            return instance;
        }
    }
}