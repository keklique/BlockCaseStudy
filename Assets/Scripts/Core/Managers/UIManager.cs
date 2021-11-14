using UnityEngine;
using UnityEngine.UI;
using Core.Menu;

namespace Core{

    namespace Managers{
        public class UIManager : SingletonPersistent<UIManager>
        {
            
            private LevelManager levelManager;
            private PageController pageController;
            [SerializeField]private GameObject vinput;
            [SerializeField]private GameObject hinput;

            // [SerializeField]private 
#region Unity Functions

            void Start(){
                levelManager = LevelManager.instance;
                pageController = PageController.instance;
            }
        
#endregion

#region Button Functions
            public void CreateGameButton(){
                int vn = int.Parse(vinput.GetComponent<InputField>().text);
                int hn = int.Parse(hinput.GetComponent<InputField>().text);
                levelManager.CreateMap(vn,hn);
                pageController.TurnPageOff(PageType.Menu);
            }

            // public void MainMenu(){
            //     pageController.TurnPageOff(PageType.Game);
            //     pageController.TurnPageOff(PageType.LevelCompleted);
            //     pageController.TurnPageOn(PageType.Menu);
            //     levelManager.DestroyLevel();
            // }
            
#endregion
        }
    }
}

