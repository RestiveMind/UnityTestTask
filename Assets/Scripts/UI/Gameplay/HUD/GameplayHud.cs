using System;
using Gameplay;
using UI.Common;

namespace UI.Gameplay
{
    public class GameplayHud : UiPresenter<IGameplayHudView, GameplayHudModel>
    {
        private GameplayHudPresenter _presenter;

        public void Init(Player player)
        {
            _presenter = new GameplayHudPresenter(View, Model, player);
        }

        private void Update()
        {
            _presenter.Update();
        }

        private void OnDestroy()
        {
            _presenter.Destroy();
        }
    }
}