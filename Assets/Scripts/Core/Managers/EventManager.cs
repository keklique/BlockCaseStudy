using UnityEngine;
using Core.Menu;
using Game;

namespace Core{

    namespace Managers{
        public class EventManager : SingletonPersistent<EventManager>
        {
            public delegate void ButtonClickedEvent(ButtonType btype,int bPosition,Vector3 Vposition);
            public event ButtonClickedEvent OnButtonClicked;

#region Button Functions
        public void ButtonClicked(ButtonType btype,int bPosition,Vector3 Vposition){
            if(OnButtonClicked != null) OnButtonClicked(btype,bPosition,Vposition);
        }
            
#endregion
        }
    }
}
