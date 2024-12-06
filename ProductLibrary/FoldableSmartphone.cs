using System.Text;
using BarcodeLibrary;

namespace ProductLibrary
{
    // доделать часть 3, шк должен быть только из 1 ид

    // sealed запрещает дальнейшее наследование
    public sealed class FoldableSmartphone : Smartphone, IProduct
    {
        /// <summary>
        /// Диагональ экрана в раскрытом виде, дюймы
        /// </summary>
        public double UnfoldedScreenSize { get; set; }
        IBarcode IProduct.ItemBarcode => new BarcodeRecord("");
        public override IBarcode ItemBarcode { get; }

        public FoldableSmartphone(int id, string model, double ramValue, double scrSizeFold, double camRes, string color, double scrSizeFull) :
            base(id, model, ramValue, scrSizeFold, camRes, color)
        {
            this.ItemBarcode = new BarcodeRecord(id.ToString());
            this.UnfoldedScreenSize = scrSizeFull;
            this.PhoneType = "Складной смартфон";
        }

        public override string ItemInfo()
        {
            StringBuilder infoBuilder = new(base.ItemInfo());
            infoBuilder.AppendFormat("{0, -20} {1}\"", "В раскрытом виде:", UnfoldedScreenSize);

            return infoBuilder.ToString();
        }
    }
}
