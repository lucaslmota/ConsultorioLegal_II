namespace Cl.Core.Shared.ModelViews
{
    public class TelefoneView : ICloneable
    {
        public int ClienteId { get; set; }
        public string Numero { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}