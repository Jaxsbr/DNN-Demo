using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNN_Demo
{
    public class InsectMatchBuilder
    {
        private Insect _insectOne;
        private Insect _insectTwo;

        public InsectMatchBuilder(Insect insectOne, Insect insectTwo)
        {
            _insectOne = insectOne;
            _insectTwo = insectTwo;
        }

        public Insect PredictWinner(List<AttributeType> attributesToFavor)
        {
            attributesToFavor = attributesToFavor.Distinct().ToList();
            var neuralNetwork = GetTrainedNetwork(attributesToFavor);
            var input = GetInput();
            var output = neuralNetwork.Think(input);

            int rowLength = output.GetLength(0);
            int colLength = output.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    // TODO: Big assumtion that ther will only be one row and column in the output
                    var val = Math.Round(output[i, j]);
                    return val == 0 ? _insectOne :_insectTwo;
                }
            }

            throw new Exception("we should have a value in the output");
        }

        public NeuralNetwork GetTrainedNetwork(List<AttributeType> attributesToFavor)
        {
            // 1-4 attributes of first actor
            // 5-8 attributes of second actor
            var trainingInputs = new double[,]
            {
                { 0, 0, 0, 0, 1, 1, 1, 1 }, // 1st
                { 1, 1, 1, 1, 0, 0, 0, 0 }, // 2nd
                //{ 1, 0, 0, 0, 0, 0, 0, 1 }, // 3rd
                //{ 1, 0, 0, 0, 0, 1, 0, 1 }, // 4rd
            };
            var trainingOutputs = NeuralNetwork.MatrixTranspose(new double[,]
            {
                {
                    1, // 1st, the second actor wins
                    0, // 2nd, the first actor wins
                    //1, // 3rd, first attribute weighs more than last attribute, thus first actor wins
                    //0, // 4th, first attribute weighs less than 2nd and last attribute combined, thus second actor wins
                }
            });

            var trainedNeuralNetwork = new NeuralNetwork(Constants.InputLayerCount, Constants.NeuronCount);
            trainedNeuralNetwork.Train(trainingInputs, trainingOutputs, 100);
            return trainedNeuralNetwork;
        }

        public double[,] GetInput()
        {
            var values = new List<double>();
            values.AddRange(_insectOne.OutputAttributeValues());
            values.AddRange(_insectTwo.OutputAttributeValues());
            var input = new double[Constants.InputLayerCount, Constants.NeuronCount];
            for (int i = 0; i < Constants.NeuronCount; i++)
            {
                input[0, i] = values[i];
            }
            return input;
        }
    }
}
