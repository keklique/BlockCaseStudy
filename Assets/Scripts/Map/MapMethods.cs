using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game{
    public static class MapMethods 
    {
        public static int[,] RotateMatrixCounterClockwise(int[,] oldMatrix)
        {
            int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }
        public static void VisualizeMatrix(int[,] matrix){
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Debug.Log(matrix[row, col] + " ");
                }

            }
        }

        public static int[,] CopyOfMatrix(int[,] baseMatrix){
            int[,] tempMatrix = new int[baseMatrix.GetLength(0),baseMatrix.GetLength(1)];
            for(int i=0;i<baseMatrix.GetLength(0);i++){
                for(int j=0;j<baseMatrix.GetLength(1);j++){
                    tempMatrix[i,j] = baseMatrix[i,j];
                }
            }
            return tempMatrix;
        }

        public static void LogMatrix(int[,] _matrix){
            Debug.Log("___________________");
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                string msgg = "";
                for (int i = 0; i < _matrix.GetLength(0); i++)
                    {
                        msgg = msgg + _matrix[i, j].ToString();
                    }
                Debug.Log(msgg);
            }
            Debug.Log("___________________");

        }

    }
}