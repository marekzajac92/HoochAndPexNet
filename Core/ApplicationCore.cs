using HoochAndPexNet.Core.Graphic.Interface;
using HoochAndPexNet.States.Manager;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;

namespace HoochAndPexNet.Core
{
    public class ApplicationCore
    {
        private RenderWindow _window;

        private IStateManager _stateManager;

        public void Initialize()
        {
            _window = new RenderWindow(new VideoMode(800, 600, 32), "Title", Styles.Default);
            _window.Closed += _window_Close;

            //_stateManager = new StateManager();
        }

        public bool Update()
        {
            _window.DispatchEvents();
            _window.Clear(Color.Red);
            return _window.IsOpen();
        }

        public void Draw()
        {
            _window.Display();
        }

        #region private_methods

        private IEnumerable<IDrawableObject> SortLayers()
        {
            return _stateManager.GetObjectsToDraw().OrderBy(s => s.Layer);
        }

        #endregion

        #region events

        private void _window_Close(object sender, System.EventArgs e)
        {
            var window = (RenderWindow)sender;
            window.Close();
        }

        #endregion
    }
}
