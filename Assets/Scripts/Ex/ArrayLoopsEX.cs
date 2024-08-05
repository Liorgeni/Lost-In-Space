using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
public class ArrayLoopsEX : MonoBehaviour
{

    int[] arr1= new int[7] {1,700,30,0,3,25,-7};
    int[] arr2 = new int[5] { 5,44,307,0,2 };

    int[] arr3 = new int[5] { 0, 44, 2, 7, 307 };
    int[] arr4 = new int[7] { 1, 99, 307, 0,-30 , 999, 2 };

    Vector3[] vectors = new Vector3[]
   {
            new Vector3(1.0f, 2.0f, 3.0f),
            new Vector3(4.3f, 5.0f, 6.0f),
            new Vector3(7.0f, 8.8f, 9.1f)
   };

    // Start is called before the first frame update
    void Start()
    {
        //---------1--------//

        //print(ReturnSmallestNumInArray(arr1)); // expected output = -7
        //print(ReturnSmallestNumInArray(arr2)); // expected output = 0

        //---------2--------//

        //print( ReturnSmallestNumPositionInArray(arr1)); // expected output = 6
        //print(ReturnSmallestNumPositionInArray(arr2));  // expected output = 3

        //---------3--------//

        //int[] reversed = ReturnReverseArray(arr2);
        //print("[" + string.Join(", ", reversed) + "]"); // expected output = [2,0,307,44,5]


        //---------4--------//

        //print(ReturnAmountOfNumbersDividedBy10(arr1)); // expected output = 2
        //print(ReturnAmountOfNumbersDividedBy10(arr2)); // expected output = 0


        //---------5--------//

        //int[] intArr = ReturIntArr(1, 10);
        //print("[" + string.Join(", ", intArr) + "]"); 


        //---------6--------//

        //print(ReturnAmountOfDuplicateNums(arr3, arr4));  // expected output = 3


        //---------7--------//

        //int[] arr3Div = ReturnArrayOfNumbersDividedBy3(arr4);
        //print("[" + string.Join(", ", arr3Div) + "]");  // expected output = [99, -30, 999]


        //---------8--------//

        //JumpThrough3DVectors(vectors);


        //---------9--------//

        //JumpThrough2DVectors(RandomVectorsPos());

    }

    static int  ReturnSmallestNumInArray(int[] nums)
    {
     int smallestNum = nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < smallestNum)
            { 
            smallestNum = nums[i];
            }
        }
        return smallestNum;
    }


    static int ReturnSmallestNumPositionInArray(int[] nums)
    {
        int smallestNumPos = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[smallestNumPos])
            {
                smallestNumPos = i;
            }
        }
        return smallestNumPos;
    }


    static int[] ReturnReverseArray(int[] nums)
    {
        int[] reverseArr = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            reverseArr[i] = nums[nums.Length - 1 - i];
            //print(nums[i]); // uncomment for each element seperated
        }
        return reverseArr;
    }


    static int ReturnAmountOfNumbersDividedBy10(int[] nums)
    {
        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 10 == 0 && nums[i] != 0)
            {
            count++; 
            }
        }
        return count;
    }


    static int[] ReturIntArr(int num1, int num2)
    {
        int arrSize = num2 - num1 -1;
        int[] intArr = new int[arrSize];

        for (int i = 0; i < arrSize; i++)
        {
            intArr[i] = num1 +i +1;
        }
        return intArr;
    }


    static int ReturnAmountOfDuplicateNums(int[] nums1, int[] nums2)
    {
        int count = 0;

        for (int i = 0; i < nums1.Length; i++)
        {
            for (int j = 0; j < nums2.Length; j++)
            {
                if (nums1[i] == nums2[j])
                {
                    count++; 
                }
            }
        }
        return count;
    }



   static int[] ReturnArrayOfNumbersDividedBy3(int[] nums)
    {
        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 3 == 0 && nums[i] != 0)
            {
                count++;
            }
        }

        int[] newArr = new int[count];
        int index = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 3 == 0 && nums[i] != 0)
            {
                newArr[index] = nums[i];
                index++;
            }
        }
        return newArr;
    }


    static void JumpThrough3DVectors(Vector2[] vectors)
    {
        for (int i = 0; i < vectors.Length; i++)
        {
           print(vectors[i]); 
        }
    }
    private float randomXPos;



    static void JumpThrough2DVectors(Vector2[] vectors)
    {
        Vector2 currentPosition = new Vector2(0.0f, 0.0f); 

        for (int i = 0; i < vectors.Length; i++)
        {
            currentPosition = vectors[i]; 
            Debug.Log($"Object jumped to: {currentPosition}");
        }
    }




    static Vector2[] RandomVectorsPos()
    {
        Vector2[] vectors = new Vector2[50];

        for (int i = 0; i < vectors.Length; i++)
        {
            int randomXPos = UnityEngine.Random.Range(1, 100);
            int randomYPos = UnityEngine.Random.Range(1, 100);

            vectors[i] = new Vector2(randomXPos, randomYPos);
        }

        return vectors; 
    }
}
