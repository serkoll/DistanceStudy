namespace GraphicsModule.Geometry
{
    public class Name
    {
        public string Value { get; set; }
        public float Dx { get; set; }
        public float Dy { get; set; }
        public Name()
        {
            Value = "";
            Dx = 0;
            Dy = 0;
        }
        public Name(Name name)
        {
            Value = name.Value;
            Dx = name.Dx;
            Dy = name.Dy;
        }
        public Name(string value, float dx, float dy)
        {
            Value = value;
            Dx = dx;
            Dy = dy;
        }
    }
}
