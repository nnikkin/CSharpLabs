using BarcodeLibrary;

namespace ProductLibrary
{
    public interface IProduct
    {
        int Id { get; set; }
        IBarcode ItemBarcode { get; }
        string Model { get; set; }
    }
}