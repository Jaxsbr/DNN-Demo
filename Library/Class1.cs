namespace Library
{
    // Neuron to Synases to Neuron
    // NeuronA value (x) -> SynaseAa (w) -> Modify value (x * w) (z) -> NeuronC
    // NeuronA value (x) -> SynaseAb (w) -> Modify value (x * w) (z) -> NeuronD
    // NeuronB value (x) -> SynaseAc (w) -> Modify value (x * w) (z) -> NeuronC
    // NeuronB value (x) -> SynaseAa (w) -> Modify value (x * w) (z) -> NeuronD

    // List of (z) values recieved and processed in Neuron
    // NeuronC sum inputs(NeuronAz + NeuronBz) (t) -> Process (t) in function f(t) -> Output to Synapses OR Output result
    // NeuronD sum inputs(NeuronAz + NeuronBz) (t) -> Process (t) in function f(t) -> Output to Synapses OR Output result


    public class Neuron
    {
        public List<object> Synases { get; private set; }

        public Neuron()
        {
            Synases = new List<object>();
        }
    }

    public class Synapse
    {
        public double Weight { get; private set; }

    }
}