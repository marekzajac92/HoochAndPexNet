using HoochAndPexNet.States.Interface;

namespace HoochAndPexNet.States.Manager
{
    public interface IStateManager
    {
        void Push(IState state);
        void Pop();
        void Update(double deltaTime);
    }
}
