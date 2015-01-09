using HoochAndPexNet.Core.Graphic.Interface;
using HoochAndPexNet.States.Interface;
using System;
using System.Collections.Generic;

namespace HoochAndPexNet.States
{
    //TODO: Dokonczyc
    public class IntroState : IState
    {
        private StateResult _result;

        public IntroState()
        {
            _result = new StateResult();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public StateResult Update(double deltaTime)
        {
            return _result;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDrawableObject> GetObjectsToDraw()
        {
            return null;
        }
    }
}
