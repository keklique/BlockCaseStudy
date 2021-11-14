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
            // Debug.Log("[Get Lenght(1)]: "+tempMatrix.GetLength(1));
            int[] tempRow = new int[tempMatrix.GetLength(1)]; // Row or column of button from left (button) to right as int[]
            for(int j=0;j<tempMatrix.GetLength(1);j++){tempRow[j] = tempMatrix[row,j];}
            int availableBlocks = CheckRowEmptySpace(tempRow); // Calculate empty blocks from button
            int[] tempcor = GetIJOfFirstEmpth(type, row, availableBlocks);
            return new int[3] {availableBlocks,tempcor[0],tempcor[1]}; //return integer array of emptyblocks, start i and j of emty blocks
        }

        public void FillMatrix(ButtonType type,int[] headCoor, int blockSize){
            if(type==ButtonType.ToRight){
                for(int i = 0;i<blockSize;i++){matrix[headCoor[0],headCoor[1]-i] = 1;}
            }

            if(type==ButtonType.ToLeft){
                for(int i = 0;i<blockSize;i++){matrix[headCoor[0],headCoor[1]+i] = 1;}
            }

            if(type==ButtonType.ToButtom){
                for(int i = 0;i<blockSize;i++){matrix[headCoor[0]-i,headCoor[1]] = 1;}
            }

            if(type==ButtonType.ToTop){
                for(int i = 0;i<blockSize;i++){matrix[headCoor[0]+i,headCoor[1]] = 1;}
            }
        }

        public int CheckLeftEmptyBlocks(){
            int _remainBlocks = 0;
            for(int i=0;i<matrix.GetLength(0);i++){
                for(int j=0;j<matrix.GetLength(0);j++){
                    if(matrix[i,j]==0){
                        _remainBlocks++;
                    }
                }
            }
            return _remainBlocks;
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
            if(type == ButtonType.ToLeft){tempcoor =  new int[2]{matrix.GetLength(0) - row - 1, matrix.GetLength(1) - availableBlocks};}
            if(type == ButtonType.ToTop){tempcoor =  new int[2]{ matrix.GetLength(0) - availableBlocks, row};}
            return tempcoor;
        }

#endregion
    }
}
