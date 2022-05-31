using System.Numerics;

namespace HexOperations
{
    public class Conventor
    {

        private int _count;
        string[] _bitString;

        internal void Initializate(string hex)
        {
            int counter = 0;
            if (hex.Length % 2 == 0) { _count = hex.Length / 2; }
            else { _count = (hex.Length + 1) / 2; }
            string[] b = new string[_count];


            for (int i = 0; i < (2 * _count); i += 2)
            {
                if ((i + 1) > (hex.Length - 1))
                {
                    b[counter] = String.Concat(hex[i], "0");
                }
                else
                {
                    b[counter++] = String.Concat(hex[i], hex[i + 1]);
                }
            }
            _bitString = b;
        }

        public BigInteger HexToLittleEndian(string hex)
        {
            if (hex == null) { return 0; }
            Initializate(hex);

            BigInteger littleEndian = new();
            int degree = 0;

            for (int i = 0; i < _bitString.Length; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    int value = _bitString[i][j] switch
                    { 'a' => 10, 'b' => 11, 'c' => 12, 'd' => 13, 'e' => 14, 'f' => 15, _ => (_bitString[i][j] - '0') };
                    littleEndian += value * (BigInteger)Math.Pow(16, degree);
                    degree++;
                }
            }

            return littleEndian;
        }

        public BigInteger HexToBigEndian(string hex)
        {
            if (hex == null) { return 0; }
            Initializate(hex);

            BigInteger bigEndian = new();
            int degree = 0;

            for (int i = _bitString.Length - 1; i >= 0; i--)
            {
                for (int j = 1; j >= 0; j--)
                {
                    int q = _bitString[i][j] switch
                    { 'a' => 10, 'b' => 11, 'c' => 12, 'd' => 13, 'e' => 14, 'f' => 15, _ => (_bitString[i][j] - '0') };
                    bigEndian += q * (BigInteger)Math.Pow(16, degree);
                    degree++;
                }
            }

            return bigEndian;
        }

        public string BigEndianToHex(BigInteger bigEndian)
        {
            if (bigEndian == null) { return "\0"; }

            BigInteger calculatedEndian = bigEndian;
            string hex = "";

            for (int i = (int)BigInteger.Log(bigEndian, 16); i >= 0; i--)
            {
                for (int j = 15; j >= 0; j--)
                {
                    if ((j * BigInteger.Pow(16, i) <= calculatedEndian))
                    {
                        hex = String.Concat(hex, j switch { 10 => "a", 11 => "b", 12 => "c", 13 => "d", 14 => "e", 15 => "f", _ => Convert.ToString(j) });
                        calculatedEndian -= j * BigInteger.Pow(16, i);
                        break;
                    }
                }
            }

            return hex;
        }

        public string LittleEndianToHex(BigInteger littleEndian, int hexLenght)
        {
            if (littleEndian == null) { return "\0"; }

            BigInteger calculatedEndian = littleEndian;
            string hex = "";
            string[] bitHex = new string[hexLenght/4];

            for (int i = (hexLenght / 4) - 1; i >= 0; i-=2)
            {
                for (int k = 1, r = 0; k >= 0; k--, r++)
                {
                    for (int j = 15; j >= 0; j--)
                    {
                        if ((j * BigInteger.Pow(16, i - r) <= calculatedEndian))
                        {
                            bitHex[i - k] = j switch { 10 => "a", 11 => "b", 12 => "c", 13 => "d", 14 => "e", 15 => "f", _ => Convert.ToString(j) };
                            calculatedEndian -= j * BigInteger.Pow(16, i);
                            break;
                        }
                    }
                }
            }

            foreach (string value in bitHex)
            {
                hex = String.Concat(hex, value);
            }

            return hex;
        }
    }
}