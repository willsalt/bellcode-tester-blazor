namespace BellTest.Internals
{
    public class BellCode
    {
        public string Code { get; private set; }

        public string Description { get; private set; }

        public BellCode(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
