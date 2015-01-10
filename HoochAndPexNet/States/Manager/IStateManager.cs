using HoochAndPexNet.Core.Graphic.Interface;
using HoochAndPexNet.States.Interface;
using System.Collections.Generic;

namespace HoochAndPexNet.States.Manager
{
    public interface IStateManager
    {
        void Update(double deltaTime);
        IEnumerable<IDrawableObject> GetObjectsToDraw();
    }
}
