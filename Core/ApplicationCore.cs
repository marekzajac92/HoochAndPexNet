using HoochAndPexNet.Core.Graphic.Interface;
using HoochAndPexNet.States.Manager;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using HoochAndPexNet.States;
using HoochAndPexNet.Resources.Manager;
using HoochAndPexNet.Core.Config;

namespace HoochAndPexNet.Core
{
    public class ApplicationCore
    {
        #region private_variables

        private RenderWindow _window;

        private IStateManager _stateManager;
        private IResourceManager _resourceManager;
        private IConfigManager _configManager;

        private Stopwatch _clock;

        #endregion

        #region public_methods

        public void Initialize()
        {
            _stateManager = new StateManager(new IntroState());
            _resourceManager = new FileResourceManager();
            _configManager = new ConfigManager(_resourceManager);
            _configManager.Load("config.xml");

            var screenWidth = (uint)_configManager.GetConfig().ScreenWidth;
            var screenHeight = (uint)_configManager.GetConfig().ScreenHeight;
            _window = new RenderWindow(new VideoMode(screenWidth, screenHeight, 32), "Title", Styles.Default);
            _window.Closed += _window_Close;

            _clock = new Stopwatch();
            _clock.Start();
        }

        public bool Update()
        {
            _window.DispatchEvents();

            _clock.Stop();
            var delta = _clock.Elapsed.TotalSeconds;
            _clock.Start();
            _stateManager.Update(delta);

            return _window.IsOpen();
        }

        public void Draw()
        {
            _window.Clear(Color.Red);
            var objectsToDraw = GetObjectsAndSortLayers();
            DrawObjects(objectsToDraw);
            _window.Display();
        }

        #endregion

        #region private_methods

        private IEnumerable<IDrawableObject> GetObjectsAndSortLayers()
        {
            var objects = _stateManager.GetObjectsToDraw();
            if (objects == null) return null;

            return objects.OrderBy(s => s.Layer);
        }

        private void DrawObjects(IEnumerable<IDrawableObject> objects)
        {
            if (objects == null) return;

            foreach(var item in objects)
            {
                _window.Draw(item.Get());
            }
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
