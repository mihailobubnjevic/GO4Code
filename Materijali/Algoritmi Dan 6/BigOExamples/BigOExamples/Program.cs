

//var n = nums.Length;
//var dict = new Dictionary<int, int>();

//for (int i = 0; i < n; i++)
//{
//    var num = nums[i];
//    var complement = target - num;

//    if (dict.ContainsKey(complement))
//        return new int[] { i, dict[complement] }

//            dict.Add(num, i);
//}

//return new int[] { -1 };

public int[] TwoSum(int[] nums, int target)
{
    var n = nums.Length;

    for (int i = 0; i < n; i++)
    {
        var num = nums[i];
        
        for (int j = i + 1; j < n; j++)
        {
            var result = num + nums[j];

            if(result == target)
                return new int[]{ i, j};
        }
    }
    return new int[] { -1 };


}



void FirstInArray(int[] array)
{
    Console.WriteLine("First element in array is: {0}", array[0]);
    Console.WriteLine("First element in array is: {0}", array[0]);
    Console.WriteLine("First element in array is: {0}", array[0]);
    Console.WriteLine("First element in array is: {0}", array[0]);
    Console.WriteLine("First element in array is: {0}", array[0]);
}

int IterateOverArray(int[] array, int element)
{
    var n = array.Length;

    for(int i = 0; i < n; i+=2)
    {
        if (array[i] == element)
            return i;
    }

    Console.WriteLine("Element at index {0} is {1}", i, array[i]);
}

// O(n^2 + n)

void IterateOverMatrix(int[][] matrix)
{
    var n = matrix[0].Length;

    for (int i = 0; i < n; ++i)
    {
        for (int j = i; j < n; ++j)
        {
            Console.WriteLine("Element at index {0},{1} is {2}", i, j, matrix[i][j]);
        }
    }
}

// n + n - 1 + n -2 .. =n*(n+1)/2 = n^2


// log

bool BinarySearch(int[] array, int element, out int? index)
{
    int min = 0;
    int max = array.Length - 1;

    while (min <= max)
    {
        int mid = (min + max) / 2;
        if (element == array[mid])
        {
            index = mid;
            return true;
        }
        else if (element < array[mid])
        {
            max = mid - 1;
        }
        else
        {
            min = mid + 1;
        }
    }

    index = null;
    return false;
}













//int Fibonacci(int n)
//{
//    if (n <= 2)
//        return 1;
//    else 
//        return Fibonacci(n - 2) + Fibonacci(n-1);
//}




//int[] BubbleSortArray(int[] array)
//{
//    var n = array.Length;
//    for (int i = 0; i < n - 1; i++)
//        for (int j = 0; j < n - i - 1; j++)
//            if (array[j] > array[j + 1])
//            {
//                var tempVar = array[j];
//                array[j] = array[j + 1];
//                array[j + 1] = tempVar;
//            }
//    return array;
//}



int[] SortArray(int[] array, int left, int right)
{
    if (left < right)
    {
        int middle = left + (right - left) / 2;
        SortArray(array, left, middle);
        SortArray(array, middle + 1, right);
        MergeArray(array, left, middle, right);
    }
    return array;
}


void MergeArray(int[] array, int left, int middle, int right)
{
    var leftArrayLength = middle - left + 1;
    var rightArrayLength = right - middle;
    var leftTempArray = new int[leftArrayLength];
    var rightTempArray = new int[rightArrayLength];
    int i, j;
    for (i = 0; i < leftArrayLength; ++i)
        leftTempArray[i] = array[left + i];
    for (j = 0; j < rightArrayLength; ++j)
        rightTempArray[j] = array[middle + 1 + j];
    i = 0;
    j = 0;
    int k = left;
    while (i < leftArrayLength && j < rightArrayLength)
    {
        if (leftTempArray[i] <= rightTempArray[j])
        {
            array[k++] = leftTempArray[i++];
        }
        else
        {
            array[k++] = rightTempArray[j++];
        }
    }
    while (i < leftArrayLength)
    {
        array[k++] = leftTempArray[i++];
    }
    while (j < rightArrayLength)
    {
        array[k++] = rightTempArray[j++];
    }
}