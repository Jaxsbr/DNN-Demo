using DNN_Demo;


// NOTE: Breaks once we go greater than 1..Why?
int synapseMatrixColumns = 2;// 1;
int synapseMatrixLines = 3;
var curNeuralNetwork = new NeuralNetWork(synapseMatrixColumns, synapseMatrixLines);

Console.WriteLine("Synaptic weights before training:");
PrintMatrix(curNeuralNetwork.SynapsesMatrix);

// Original input
//var trainingInputs = new double[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 } };
//var trainingOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 0, 1, 1, 0 } });

var trainingInputs = new double[,] 
{ 
    { 0, 0, 1 },
    { 0, 1, 1 },
    { 1, 0, 1 },
    { 0, 1, 0 },
    { 1, 0, 0 },
    { 1, 1, 1 },
    { 0, 0, 0 }
};
var trainingOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 0, 1, 1, 1, 1, 0, 0 } });

curNeuralNetwork.Train(trainingInputs, trainingOutputs, 10);

Console.WriteLine("\nSynaptic weights after training:");
PrintMatrix(curNeuralNetwork.SynapsesMatrix);


// testing neural networks against a new problem 
var output = curNeuralNetwork.Think(new double[,] { { 1, 1, 0 } });
Console.WriteLine("\nConsidering new problem [1, 1, 0] => :");
PrintMatrix(output);

Console.Read();


static void PrintMatrix(double[,] matrix)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            Console.Write(string.Format("{0} ", matrix[i, j]));
        }
        Console.Write(Environment.NewLine);
    }
}
