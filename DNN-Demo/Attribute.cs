namespace DNN_Demo
{
    public struct Attribute
    {
        public AttributeType AttributeType { get; private set; }
        public byte HasAttribute { get; private set; }

        public Attribute(AttributeType attributeType, bool hasAttribute)
        {
            AttributeType = attributeType;
            HasAttribute = Convert.ToByte(hasAttribute);
        }        
    }
}
