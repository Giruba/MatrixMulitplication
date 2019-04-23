using System;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Efficient way of multiplying matrices!");
            Console.WriteLine("--------------------------------------");

            int[] matrixDimensionsArray = GetMatrixDimensionArrayFromInput();
            Console.WriteLine("The efficient way of multiplying the matrix dimensions" +
                " results in "+PrintEfficientMultiplications(matrixDimensionsArray));

            Console.ReadLine();
        }

        private static int[] GetMatrixDimensionArrayFromInput() {

            int[] matrixofDimensions = null;

            Console.WriteLine("Enter the number of elements in the " +
                "dimensions matrix");
            try {
                int noElements = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the elements separated by space," +
                    "comma or semi-colon");
                String[] elements = Console.ReadLine().Split(' ', ';', ',');
                matrixofDimensions = new int[noElements];
                for (int index = 0; index < noElements; index++) {
                    matrixofDimensions[index] = int.Parse(elements[index]);
                }

            }
            catch(Exception exception){
                Console.WriteLine("Thrown exception is " +
                    ""+exception.Message);
            }

            return matrixofDimensions;
        }


        private static int PrintEfficientMultiplications(int[] matrixDimensionsArray)
        {
            int length = matrixDimensionsArray.Length;
            int[,] minMatrixCals = new int[length, length];

            for (int index = 1; index < length; index++) {
                minMatrixCals[index, index] = 0;
            }

            for (int numberOfMatrices = 2; numberOfMatrices < length; numberOfMatrices++) {
                for (int startIndex = 1; startIndex < length - numberOfMatrices + 1; startIndex++) {
                    int endIndex = startIndex + numberOfMatrices - 1;
                    minMatrixCals[startIndex, endIndex] = int.MaxValue;
                    for (int intermediateMatrixIndex = startIndex; intermediateMatrixIndex < endIndex; intermediateMatrixIndex++) {
                        int actualComputation =
                            minMatrixCals[startIndex, intermediateMatrixIndex] +
                            minMatrixCals[intermediateMatrixIndex + 1, endIndex] +
                            matrixDimensionsArray[startIndex - 1] * matrixDimensionsArray[intermediateMatrixIndex] * matrixDimensionsArray[endIndex];

                        if (actualComputation < minMatrixCals[startIndex, endIndex]) {
                            minMatrixCals[startIndex, endIndex] = actualComputation;
                        }
                    }
                }
            }
            return minMatrixCals[1,length-1];
        }
    }
}
