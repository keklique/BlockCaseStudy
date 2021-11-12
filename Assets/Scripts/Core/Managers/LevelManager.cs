using UnityEngine;
using Game;
using Core.Menu;


namespace Core{

    namespace Managers{
        public class LevelManager : SingletonPersistent<LevelManager>
        {
            private PageController pageController;
            public Map currentMap;
            public GameObject mapObject;
            public GameObject blockPrefab;
            public GameObject buttonPrefab;




        #region  Unity Functions
                void Start(){
                    Application.targetFrameRate = 30;
                    pageController = PageController.instance;
                    // CreateMap(3,5);
                }
        #endregion

        #region  Public Functions
                public void CreateMap(int x, int y){
                    if(mapObject != null){
                        currentMap.Dispose();
                        Destroy(mapObject);
                    }
                    mapObject = new GameObject("Level",typeof(Map));
                    currentMap = mapObject.GetComponent<Map>();
                    currentMap.SetSizes(x,y);
                    currentMap.SetPrefabs(blockPrefab, buttonPrefab);
                    currentMap.CreateMap();
                }
        #endregion

        #region  private Functions
                
        #endregion
        }
    }
}