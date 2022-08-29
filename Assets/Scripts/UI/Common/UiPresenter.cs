using UnityEngine;

namespace UI.Common
{
    public class UiPresenter<TView, TModel> : MonoBehaviour where TModel : new()
    {
        protected TView View { get; private set; }
        protected TModel Model { get; private set; }
        
        private void Awake()
        {
            View = GetComponent<TView>();
            Model = new TModel();
        }
    }
}