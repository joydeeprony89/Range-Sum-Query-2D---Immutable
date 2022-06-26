using System;

namespace Range_Sum_Query_2D___Immutable
{
  // https://leetcode.com/problems/range-sum-query-2d-immutable/
  // https://www.youtube.com/watch?v=KE8MQuwE2yA
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }

  public class NumMatrix
  {
    int[,] dp;
    public NumMatrix(int[][] matrix)
    {
      int row = matrix.Length;
      int column = matrix[0].Length;
      dp = new int[row + 1, column + 1];
      for (int i = 0; i < row; i++)
      {
        int prefixSum = 0;
        for (int j = 0; j < column; j++)
        {
          prefixSum += matrix[i][j];
          int aboveSum = dp[i, j + 1];
          dp[i + 1, j + 1] = prefixSum + aboveSum;
        }
      }
    }

    public int SumRegion(int r1, int c1, int r2, int c2)
    {
      // Why adding +1 ? As our DP array has +1 row and +1 column
      // so added +1 for each position to refer the same in the PD array
      r1 += 1; r2 += 1; c1 += 1; c2 += 1;
      int bottomRight = dp[r2, c2];
      int aboveRight = dp[r1 - 1, c2];
      int left = dp[r2, c1 - 1];
      int topLeft = dp[r1 - 1, c1 - 1];
      return bottomRight - aboveRight - left + topLeft;
    }
  }

  /**
   * Your NumMatrix object will be instantiated and called as such:
   * NumMatrix obj = new NumMatrix(matrix);
   * int param_1 = obj.SumRegion(row1,col1,row2,col2);
   */
}
