// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

/*bool[,] matrix = new bool[,]
            {
                {false, false, false, false, true, true, false},
                {false, false, true, false, false, false, false},
                {false, true, false, true, false, false, false},
                {false, false, true, false, false, false, true},
                {true, false, false, false, false, false, true},
                {true, false, false, false, false, false, false},
                {false, false, false, true, true, false, false},

            };*/
bool[,] matrix = new bool[,]
            {
                {false, true, false, false, true},
                {true, false, false, false, false},
                {false, false, false, true, false},
                {false, false, true, false, false},
                {true, false, false, false, false}
            };

Console.WriteLine("Result: " + GetMinimumConnections(matrix));
Console.ReadLine();


int GetMinimumConnections(bool[,] matrix)
{
    int len = (int)Math.Sqrt(matrix.Length);
    int[] peak = new int[len];
    Array.Fill(peak, -1);
    int nGroup = 0;

    for (int index = 0; index < len; index++)
    {
        if (peak[index] == -1)
        {
            nGroup++;
        }
        DQ(ref peak, matrix, index, nGroup);
    }

    return nGroup - 1;

    /*foreach (int index in peak)
    {
        Console.WriteLine(index);
    }*/

    //Console.WriteLine("n = " + nGroup);
    //throw new NotImplementedException("Waiting to be implemented.");
}


static void DQ(ref int[] arrPeak, bool[,] matrix, int peak, int nGroup)
{
    if (arrPeak[peak] == -1)
    {
        arrPeak[peak] = nGroup;
        for (int i = 0; i < arrPeak.Length; ++i)
        {
            if (matrix[peak, i] == true)
               DQ(ref arrPeak, matrix, i, nGroup);

        }
    }

}


