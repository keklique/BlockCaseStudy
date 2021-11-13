
using UnityEngine;
using Core.Managers;

namespace Game{
    public class Button : MonoBehaviour
    {


        EventManager eventManager;
        public ButtonType buttonType;
        public int buttonPosition;

        void Start(){
            eventManager = EventManager.instance;
        }
        void OnMouseDown(){
            eventManager.ButtonClicked(buttonType,buttonPosition,transform.position);
        }

#region Private Functions
        
#endregion
    }
}
