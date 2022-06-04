using DNN_Demo;


int synapseMatrixColumns = 1; // represents the columns of inputs
int synapseMatrixLines = 8; // represents the neuron count
var curNeuralNetwork = new NeuralNetWork(synapseMatrixColumns, synapseMatrixLines);

Console.WriteLine("Synaptic weights before training:");
PrintMatrix(curNeuralNetwork.SynapsesMatrix);


var trainingInputs = new double[,]
{
    { 0, 0, 0, 0, 1, 1, 1, 1 },
    { 1, 1, 1, 1, 0, 0, 0, 0 }
};
var trainingOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 1, 0 } });

curNeuralNetwork.Train(trainingInputs, trainingOutputs, 100);

Console.WriteLine("\nSynaptic weights after training:");
PrintMatrix(curNeuralNetwork.SynapsesMatrix);


// testing neural networks against a new problem 
//var output = curNeuralNetwork.Think(new double[,] { { 0, 1, 1 } });
//Console.WriteLine("\nConsidering new problem [1, 0, 0] => :");

var output = curNeuralNetwork.Think(new double[,] { { 0, 1, 1, 1, 0, 0, 0, 1 } });
Console.WriteLine("\nConsidering new problem [0, 1, 1, 1, 0, 0, 0, 1] => :");
PrintMatrix(output, true);

output = curNeuralNetwork.Think(new double[,] { { 0, 0, 0, 1, 0, 1, 1, 1 } });
Console.WriteLine("\nConsidering new problem [0, 0, 0, 1, 0, 1, 1, 1] => :");

PrintMatrix(output, true);



Console.Read();


static void OriginalSample()
{
    // Original input
    //var trainingInputs = new double[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 } };
    //var trainingOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 0, 1, 1, 0 } });
}

static void XORWithReverseSample()
{
    // Values 1 & 2 in the input matrix
    // 0 & 0 = 0
    // 0 & 1 = 1
    // 1 & 0 = 1
    // 1 & 1 = 1
    // Value 3 = 1 -> value (1 &  2) reverse
    // Value 3 = 0 -> value (1 & 2) unchanged

    //var trainingInputs = new double[,] 
    //{ 
    //    { 0, 0, 1 },// 0 -> apply 1 = 1   
    //    { 0, 0, 0 },// 0 -> apply 0 = 0
    //    { 1, 0, 1 },// 1 -> apply 1 = 0
    //    { 1, 0, 0 },// 1 -> apply 0 = 1
    //    { 0, 1, 1 },// 1 -> apply 1 = 0
    //    { 0, 1, 0 },// 1 -> apply 0 = 1
    //    { 1, 1, 1 },// 1 -> apply 1 = 0
    //    { 1, 1, 0 },// 1 -> apply 0 = 1
    //};
    //var trainingOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 1, 0, 0, 1, 0, 1, 0, 1 } });
}

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
