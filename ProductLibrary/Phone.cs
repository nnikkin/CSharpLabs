using System.Text;
using BarcodeLibrary;

namespace ProductLibrary
{
    public abstract class Phone : IProduct
    {
        private int _id;

        public IBarcode ItemBarcode { get; set; }
        public int Id {
            get => _id; 
            set {
                _id = value;
                ItemBarcode = new Barcode(_id.ToString()); 
            }
        }

        /// <summary>
        /// Бренд и модель
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Вид телефона
        /// </summary>
        public string PhoneType { get; set; }

        protected Phone(int id, string model_name)
        {
            ItemBarcode = new Barcode(id.ToString());
            Id = id;
            Model = model_name;
            PhoneType = "Телефон";
        }

        public abstract string ItemInfo();

        public override string ToString() => new StringBuilder($"{PhoneType} {Model}\n{ItemInfo()}\n{ItemBarcode}\n").ToString();
    }
}