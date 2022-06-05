using DNN_Demo;


//int synapseMatrixColumns = 1; // represents the columns of inputs
//int synapseMatrixLines = 8; // represents the neuron count
//var curNeuralNetwork = new NeuralNetwork(synapseMatrixColumns, synapseMatrixLines);

//Console.WriteLine("Synaptic weights before training:");
//PrintMatrix(curNeuralNetwork.SynapsesMatrix);


//// 1-4 attributes of first actor
//// 5-8 attributes of second actor
//var trainingInputs = new double[,]
//{
//    { 0, 0, 0, 0, 1, 1, 1, 1 }, // 1st
//    { 1, 1, 1, 1, 0, 0, 0, 0 }, // 2nd
//    { 1, 0, 0, 0, 0, 0, 0, 1 }, // 3rd
//    { 1, 0, 0, 0, 0, 1, 0, 1 }, // 4rd
//};
//var trainingOutputs = NeuralNetwork.MatrixTranspose(new double[,]
//{
//    {
//        1, // 1st, the second actor wins
//        0, // 2nd, the first actor wins
//        1, // 3rd, first attribute weighs more than last attribute, thus first actor wins
//        0, // 4th, first attribute weighs less than 2nd and last attribute combined, thus second actor wins
//    }
//});

//curNeuralNetwork.Train(trainingInputs, trainingOutputs, 100);
//Console.WriteLine("\nSynaptic weights after training:");
//PrintMatrix(curNeuralNetwork.SynapsesMatrix);


//RunPrediction(curNeuralNetwork, new double[,] { { 0, 1, 1, 1, 0, 0, 0, 1 } });
//RunPrediction(curNeuralNetwork, new double[,] { { 1, 0, 0, 0, 0, 1, 1, 1 } });




var insectA = new Insect(false, false, true, true);
var insectB = new Insect(false, false, false, true);
var matchBuilder = new InsectMatchBuilder( insectA, insectB );

var insect = matchBuilder.PredictWinner(new List<AttributeType>());
var winnerName = insect.Id == insectA.Id ? "InsectA" : "other";
winnerName = insect.Id == insectB.Id ? "InsectB" : winnerName;

Console.WriteLine("Match up: InsectA VS InsectB");
Console.WriteLine($"InsectA: {insectA}");
Console.WriteLine($"InsectB: {insectB}");
Console.WriteLine();
Console.WriteLine($"Winner:{winnerName}");


Console.Read();


static void PrintMatrix(double[,] matrix, bool includeRounded = false)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            Console.Write($"raw: {matrix[i, j]}");
            if (includeRounded)
            {
                var val = Math.Round(matrix[i, j]);
                Console.WriteLine($" rounded: {val}");
            }
        }
        Console.Write(Environment.NewLine);
    }
}

static void RunPrediction(NeuralNetwork curNeuralNetwork, double[,] input)
{
    double[,] output = curNeuralNetwork.Think(input);        
    Console.WriteLine($"\nConsidering new problem [{input[0,0]}, {input[0,1]}, {input[0,2]}, {input[0,3]}, {input[0, 4]}, {input[0, 5]}, {input[0, 6]}, {input[0, 7]}] => :");
    PrintMatrix(output, true);    
}