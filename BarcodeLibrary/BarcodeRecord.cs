namespace BarcodeLibrary
{
    public record class BarcodeRecord : IBarcode
    {
        private string _barcode { get; set; }
        private string _text { get; set; }

        /// <summary>
        /// для изменения типа вывода
        /// </summary>
        public static BarcodeType Type { get; set; } = BarcodeType.Full;
        public string Text
        {
            get => _text;
            set
            {
                if (_text == value) { return; }
                _text = value;
                _barcode = BarcodeHelper.GetCode(value);
            }
        }
        
        public BarcodeRecord(string text)
        {
            Text = text;
            _barcode = BarcodeHelper.GetCode(text);
        }
        public override string ToString()
        {
            return Type switch
            {
                BarcodeType.Text => "* " + _text + " *",
                BarcodeType.Barcode => _barcode,
                BarcodeType.Full => $"{_barcode}{("* " + _text + " *").PadLeft(3 + _barcode.Length / 12)}",
                _ => "Oops, something is clearly wrong here!",
            };
        }
    }
}
