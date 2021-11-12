using System.Collections;
using UnityEngine;

namespace Game{
    public class MapMatrix : MonoBehaviour
    {
        public int[,] matrix;
        private int[] mapSize;

        public MapMatrix(int x, int y){
            matrix = new int[x,y];
        }

#region  Unity Functions

#endregion

#region  Public Functions
        public int[] CheckEmptyBlocks(ButtonType type, int row){
            int[,] tempMatrix = GetRotatedMatrix(type); //Rotate matrix based on type of button
            int[] tempRow = new int[tempMatrix.GetLength(1)]; // Row or column of button from left (button) to right as int[]
            for(int j=0;j<tempMatrix.GetLength(1);j++){tempRow[j] = tempMatrix[row,j];}
            int availableBlocks = CheckRowEmptySpace(tempRow); // Calculate empty blocks from button
            int[] tempcor = GetIJOfFirstEmpth(type, row, availableBlocks);
            return new int[3] {availableBlocks,tempcor[0],tempcor[1]}; //return integer array of emptyblocks, start i and j of emty blocks
        }

        public void FillMatrix(ButtonType type,int[] coor, int blockSize){
        }
#endregion

#region  private Functions
        private int[,] GetRotatedMatrix(ButtonType type){
            return RotateMatrix((byte)type);
        }
        private int[,] RotateMatrix(byte times){
            int[,] tempMatrix = matrix;

            for(int i = 0; i<times;i++){
                tempMatrix =  MapMethods.RotateMatrixCounterClockwise(tempMatrix);
            }
            
            return tempMatrix;
        }

        private int CheckRowEmptySpace(int[] row){
            int emptySpace = 0;
            foreach(int k in row){
                if(k==0){
                    emptySpace++;
                }else{
                    return emptySpace;
                }
            }
            return emptySpace;
        }

        private int[] GetIJOfFirstEmpth(ButtonType type, int row, int availableBlocks){
            int[] tempcoor = new int[2];
            if(type == ButtonType.ToRight){tempcoor =  new int[2]{row, availableBlocks -1};}
            if(type == ButtonType.ToButtom){tempcoor =  new int[2]{availableBlocks -1, matrix.GetLength(1) - row - 1};}
            if(type == ButtonType.ToLeft){tempcoor =  new int[2]{matrix.GetLength(0) - row - 1, matrix.GetLength(0) - availableBlocks};}
            if(type == ButtonType.ToTop){tempcoor =  new int[2]{ matrix.GetLength(1) - availableBlocks, row};}
            return tempcoor;
        }

#endregion
    }
}
