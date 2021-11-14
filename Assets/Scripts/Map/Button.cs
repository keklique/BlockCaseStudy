using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;

namespace Game{
    public class Button : MonoBehaviour
    {
        EventManager eventManager;
        public ButtonType buttonType;
        public int buttonPosition;
        [SerializeField]private GameObject buttonSign1;
        [SerializeField]private GameObject buttonSign2;

        void Start(){
            eventManager = EventManager.instance;
            RotateButton();
        }
        void OnMouseDown(){
            eventManager.ButtonClicked(buttonType,buttonPosition,transform.position);
            StartCoroutine(ButtonClicked());
        }



#region Private Functions
        private void RotateButton(){
            transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,(byte)buttonType*-90);
        }

        private IEnumerator ButtonClicked(){
            buttonSign1.GetComponent<MeshRenderer>().material.color =Color.white;
            buttonSign2.GetComponent<MeshRenderer>().material.color =Color.white;
            yield return new WaitForSeconds(.25f);
            buttonSign1.GetComponent<MeshRenderer>().material.color =Color.grey;
            buttonSign2.GetComponent<MeshRenderer>().material.color =Color.grey;
            yield return new WaitForSeconds(.25f);
            buttonSign1.GetComponent<MeshRenderer>().material.color =Color.white;
            buttonSign2.GetComponent<MeshRenderer>().material.color =Color.white;
            yield return new WaitForSeconds(.25f);
            buttonSign1.GetComponent<MeshRenderer>().material.color =Color.grey;
            buttonSign2.GetComponent<MeshRenderer>().material.color =Color.grey;
            
        }
#endregion
    }
}
