namespace GraphicsModule.Geometry
{
    public class Name
    {
        public string Value { get; set; }
        public float Dx { get; set; }
        public float Dy { get; set; }
        public bool IsDraw { get; set; }
        public Name()
        {
            Value = "";
            Dx = 0;
            Dy = 0;
            IsDraw = true;
        }
        public Name(Name name)
        {
            Value = name.Value;
            Dx = name.Dx;
            Dy = name.Dy;
            IsDraw = name.IsDraw;
        }
        public Name(string value, float dx, float dy)
        {
            Value = value;
            Dx = dx;
            Dy = dy;
            IsDraw = true;
        }
        public Name(string value, float dx, float dy, bool isDraw)
        {
            Value = value;
            Dx = dx;
            Dy = dy;
            IsDraw = isDraw;
        }
    }
}
