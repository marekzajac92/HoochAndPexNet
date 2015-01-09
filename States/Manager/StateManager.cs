using HoochAndPexNet.Core.Graphic.Interface;
using HoochAndPexNet.States.Interface;
using System.Collections.Generic;
using System.Linq;

namespace HoochAndPexNet.States.Manager
{
    public class StateManager : IStateManager
    {
        private ICollection<IState> _statesStack;

        public StateManager(IState startState)
        {
            _statesStack = new List<IState>
            {
                startState
            };
        }

        public void Update(double deltaTime)
        {
            var result = _statesStack.Last().Update(deltaTime);
            if(result.PopState)
            {
                _statesStack.Remove(_statesStack.Last());
            }
        }

        public IEnumerable<IDrawableObject> GetObjectsToDraw()
        {
            return _statesStack.Last().GetObjectsToDraw();
        }
    }
}
