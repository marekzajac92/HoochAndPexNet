using HoochAndPexNet.Resources.Manager;

namespace HoochAndPexNet.States.Interface
{
    public interface IState
    {
        void Run();
        StateResult Update(double deltaTime);
        void Stop();
        void Pause();
    }
}
