namespace DNN_Demo
{
    public class Insect
    {
        public Guid Id;
        private Attribute _strength;
        private Attribute _speed;
        private Attribute _toughness;
        private Attribute _rested;

        public Insect(bool hasStrength, bool hasSpeed, bool hasToughness, bool hasRested)
        {
            Id = Guid.NewGuid();
            _strength = new Attribute(AttributeType.Strength, hasStrength);
            _speed = new Attribute(AttributeType.Speed, hasSpeed);
            _toughness = new Attribute(AttributeType.Toughness, hasToughness);
            _rested = new Attribute(AttributeType.Rested, hasRested);
        }

        public List<double> OutputAttributeValues()
        {
            return new List<double>()
            {
                _strength.HasAttribute,
                _speed.HasAttribute,
                _toughness.HasAttribute,
                _rested.HasAttribute
            };
        }

        public override string ToString()
        {
            var strength = _strength.HasAttribute == 1 ? "strength " : "";
            var speed = _speed.HasAttribute == 1 ? "speed " : "";
            var toughness = _toughness.HasAttribute == 1 ? "toughness " : "";
            var rested = _rested.HasAttribute == 1 ? "rested" : "";
            return $"{strength}{speed}{toughness}{rested}";
        }
    }
}
