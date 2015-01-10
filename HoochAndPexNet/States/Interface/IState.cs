using HoochAndPexNet.Core.Graphic.Interface;
using HoochAndPexNet.Resources.Manager;
using System.Collections.Generic;

namespace HoochAndPexNet.States.Interface
{
    public interface IState
    {
        void Run();
        StateResult Update(double deltaTime);
        void Stop();
        void Pause();
        IEnumerable<IDrawableObject> GetObjectsToDraw();
    }
}
