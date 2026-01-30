public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        int yLen = matrix.Length;
PriorityQueue<(int val, int row, int col), int> pq = new();

for (int i = 0; i < yLen; i++)
    pq.Enqueue((matrix[i][0], i, 0), matrix[i][0]);

for (int i = 0; i < k - 1; i++)
{
    var (val, row, col) = pq.Dequeue();
    if (++col < yLen)
        pq.Enqueue((matrix[row][col], row, col), matrix[row][col]);
}

return pq.Dequeue().val;
    }
}