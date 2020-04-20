using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeQueue
{
    class DEQueue
    {
        private int[] myArray;
        public int[] MyArray { get { return myArray; } }
        public int Left { get; set; }//where the next left
        public int Right { get; set; }//where is next right
        public int Count { get; set; }
        public DEQueue()
        {
            myArray = new int[10];
            Left = 0;
            Right =0;
            Count = 0;
        }
        public DEQueue(int size)
        {
            if (size < 1)
            {
                myArray = new int[10];
            }
            myArray = new int[size];
            Left = 0;
            Right =0;
            Count = 0;
        }
        //wrap if needed if full double and copy
        //add to left most side of array
        public void AddLeft(int val)
        {
            if (Count > myArray.Length)
                DoubleSize();           
            if (Left == myArray.Length)
                Left = 0;
            Count += 1;
            myArray[Left] = val;
            Left++;
            Right++;
        }
        public void DoubleSize()
        {
            Array.Resize(ref myArray, myArray.Length * 2);
        }
        public int GetLeft()
        {
            if(Count==0)
            {
                throw new IndexOutOfRangeException("Its empty");
            }
            if (Left >= myArray.Length)
            {
                Left = 0;
            }
            try
            {
                Count--;
                int val = Left;
                Left++;               
                return myArray[val];
            }
            catch
            {
                throw new System.ArgumentException("Get Left Out of Range");
            }
        }
        public void AddRight(int val)
        {
            if (Count > myArray.Length)
                DoubleSize();                      
            if (Right >= myArray.Length)
                Right = 0;
            Count += 1;
            myArray[Right] = val;
            Left += 1;
            Right++;
        }
        public int GetRight()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Its empty");
            }
            if (Right>=myArray.Length)
            {
                Right = 0;
            }
            try
            {
                Count--;
                int val = Right;
                Right++;
                return myArray[val];
            }
            catch
            {
                throw new System.ArgumentException("Get Right Out of Range");
            }
        }
        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            return false;
        }
        public bool IsFull()
        {
            if (Count == myArray.Length)
            {
                return true;
            }
            else
                return false;
        }
        public string ListLeftRight()
        {
            string message = "";
            if (Count == 0)
            {
                message = "Q is empty";
                return message;
            }

            foreach (int i in myArray)
            {
                message += i.ToString()+" ";
            }
            return message;
        }
        public int Size()
        {
            return myArray.Length;
        }


    }
}
