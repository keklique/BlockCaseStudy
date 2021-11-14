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
            [SerializeField]private GameObject blockPrefab;
            [SerializeField]private GameObject buttonPrefab;
            [SerializeField]private GameObject containerPrefab;
            public int currentBlockSize = 3;




        #region  Unity Functions
                void Start(){
                    Application.targetFrameRate = 30;
                    pageController = PageController.instance;
                }
        #endregion

        #region  Public Functions
                public void CreateMap(int x, int y){
                    if(mapObject != null){
                        DestroyLevel();
                    }
                    mapObject = new GameObject("Level",typeof(Map));
                    currentMap = mapObject.GetComponent<Map>();
                    currentMap.SetSizes(x,y);
                    currentMap.SetPrefabs(blockPrefab, buttonPrefab,containerPrefab);
                    currentMap.CreateMap();
                    pageController.TurnPageOn(PageType.Game);
                }

                public void SetCurrentBlockSize(int _blockSize){
                    currentBlockSize = _blockSize;
                }

                public void LevelCompleted(){
                    pageController.TurnPageOn(PageType.LevelCompleted);
                }

                public void DestroyLevel(){
                    currentMap.Dispose();
                    Destroy(mapObject);
                }

        #endregion

        #region  private Functions
                
        #endregion
        }
    }
}