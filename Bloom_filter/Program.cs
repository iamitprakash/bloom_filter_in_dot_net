using System.Collections;

namespace Bloom
{
    class Bloom
    {
        private BitArray bits = new BitArray(32);

        // two toy hashing functions,
        private Int16 rotateMore(String AddString)
        {
            Int16 ReturnValue = 0;
            for (int i = 0; i < AddString.Length; i++)
            {
                ReturnValue += (Int16)((int)AddString[i] * i);
                ReturnValue = (Int16)(ReturnValue % 32);
            }
            return ReturnValue;
        }

        private Int16 rotate(String AddString)
        {
            Int16 ReturnValue = 0;
            for (int i = 0; i < AddString.Length; i++)
            {
                ReturnValue += (Int16)((int)AddString[i]);
                ReturnValue = (Int16)(ReturnValue % 32);
            }
            return ReturnValue;
        }
        public void add(String AddString)
        {
            Console.WriteLine("adding " + AddString);

            Int16 Point1 = this.rotate(AddString);
            Int16 Point2 = this.rotateMore(AddString);
            this.bits[Point1] = true;
            this.bits[Point2] = true;

        }
        public bool contains(String CheckString)
        {
            Int16 Point1 = this.rotate(CheckString);
            Int16 Point2 = this.rotateMore(CheckString);
            if (this.bits[Point1] && this.bits[Point2])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void checkFor(String key)
        {
            if (this.contains(key))
            {
                Console.WriteLine(key + " may be in there");
            }
            else
            {
                Console.WriteLine(key + " is not there");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bloom bloom = new Bloom();
            bloom.add("string");
            bloom.add("fresh");
            bloom.add("basketball");
            bloom.checkFor("basketball");
            bloom.checkFor("soccer");
            Console.ReadLine();
        }
    }
}