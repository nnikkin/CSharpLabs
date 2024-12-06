using BarcodeLibrary;

namespace ProductLibrary
{
    public interface IProduct
    {
        public int Id { get; }
        public IBarcode ItemBarcode { get; }
        public string Model { get; }
    }
}