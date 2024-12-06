using BarcodeLibrary;
using System.Text;

namespace ProductLibrary
{
    public class Smartphone : Phone
    {

        /// <summary>
        /// ОЗУ, ГБ
        /// </summary>
        public double Ram { get; set; }

        /// <summary>
        /// Диагональ экрана, дюймы
        /// </summary>
        public double ScreenSize { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Задняя камера, МП
        /// </summary>
        public double MainCameraRes { get; set; }

        public override IBarcode ItemBarcode {  get; }

        public Smartphone(int id, string model, double ramValue, double screenInches, double resolution, string color) : base(id, model)
        {
            this.ItemBarcode = new Barcode(Id.ToString());
            this.Ram = ramValue;
            this.ScreenSize = screenInches;
            this.MainCameraRes = resolution;
            this.Color = color;
            this.PhoneType = "Смартфон";
        }

        public override string ItemInfo()
        {
            StringBuilder infoBuilder = new(string.Format("{0, -20} {1}\n", "Цвет:", Color));
            infoBuilder.AppendLine(string.Format("{0, -20} {1} ГБ", "ОЗУ:", Ram));
            infoBuilder.AppendLine(string.Format("{0, -20} {1} МП", "Задняя камера:", MainCameraRes));
            infoBuilder.AppendLine(string.Format("{0, -20} {1}\"", "Диагональ экрана:", ScreenSize));

            return infoBuilder.ToString();
        }
    }
}
