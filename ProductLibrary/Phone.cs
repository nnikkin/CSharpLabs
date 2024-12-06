using System.Text;
using BarcodeLibrary;

namespace ProductLibrary
{
    public abstract class Phone : IProduct
    {
        private int _id;

        public abstract IBarcode ItemBarcode { get; }
        public int Id {
            get => _id;
            set {
                _id = value;
                ItemBarcode.Text = _id.ToString();
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
            this._id = id;
            Model = model_name;
            PhoneType = "Телефон";
        }

        public abstract string ItemInfo();
        public override string ToString() => new StringBuilder($"{PhoneType} {Model}\n{ItemInfo()}\n{ItemBarcode}\n").ToString();
    }
}