using System.Text;
using BarcodeLibrary;
using ProductLibrary;

namespace ShowcaseLibrary
{
    public class Showcase<T> : IShowcase<T> where T : class, IProduct
    {
        private static int count;
        private T[] _phones;
        private int _showcaseId;

        /// <summary>
        /// ИД витрины
        /// </summary>
        public int ShowcaseId
        {
            get => _showcaseId;
            set
            {
                if (_showcaseId == value) return;
                _showcaseId = value;
                for (int i = 0; i < Capacity; i++)
                    UpdateItemBarcode(_phones[i], i);
            }
        }

        /// <summary>
        /// Вместительность витрины
        /// </summary>
        public int Capacity { get; set; }

        private Showcase(int capacity)
        {
            Capacity = capacity;
            _phones = new T[Capacity];
            ShowcaseId = count++;
        }
        private Showcase(int id, int capacity)
        {
            ShowcaseId = id;
            Capacity = capacity;
            _phones = new T[Capacity];
            count++;
        }

        public static implicit operator Showcase<T>(int size) => new(size);
        public static implicit operator Showcase<T>((int size, int id) v) => new(v.size, v.id);

        /// <summary>
        /// Обновляет штрих-код одной позиции
        /// </summary>
        private void UpdateItemBarcode(T phone, int new_index)
        {
            if (phone != null)
            {
                string new_text = phone.Id + " " + ShowcaseId + " " + new_index;
                phone.ItemBarcode.Text = new_text;
            }
        }

        private void UpdateAll()
        {
            for (int i = 0; i < _phones.Length; i++)
                if (_phones[i] != null)
                    UpdateItemBarcode(_phones[i], i);
        }

        /// <summary>
        /// Добавление в первую пустую позицию
        /// </summary>
        public void Add(T phone)
        {
            if (phone == null) return;

            for (int i = 0; i < Capacity; i++)
            {
                if (_phones[i] == null)
                {
                    this[i] = phone;
                    break;
                }
            }
        }

        /// <summary>
        /// Добавление товара в конкретную позицию витрины
        /// </summary>
        public void Add(int index, T phone)
        {
            this[index] = phone;
        }

        /// <summary>
        /// Удаление товара из первой позиции витрины
        /// </summary>
        public void Delete()
        {
            for (int i = Capacity - 1; i >= 0; i--)
            {
                this[i] = null;
                break;
            }
        }

        /// <summary>
        /// Удаление товара по его позиции в витрине
        /// </summary>
        public void Delete(int index)
        {
            this[index] = null;
        }

        /// <summary>
        /// Меняет местами два товара в витрине
        /// </summary>
        public void Swap(int index1, int index2)
        {
            (_phones[index1], _phones[index2]) = (_phones[index2], _phones[index1]);
        }


        /// <summary>
        /// Замена товара на витрине в заданной позиции на новый
        /// </summary>
        public void ReplaceItem(int index, T phone)
        {
            Add(index, phone);
        }

        /// <summary>
        /// Поиск позиции товара по наименованию
        /// </summary>
        public int Search(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < Capacity; i++)
                    if (_phones[i] != null && _phones[i].Model.Contains(name))
                        return i;
            }

            return -1;
        }

        /// <summary>
        /// Поиск позиции товара по индексу
        /// </summary>
        public int Search(int id)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (_phones[i] != null && _phones[i].Id == id) return i;
                else continue;
            }
            return -1;
        }

        /// <summary>
        /// Сортировка товаров по наименованию
        /// </summary>
        public void SortById()
        {
            if (_phones == null) return;

            int step = _phones.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < _phones.Length - step; i++)
                {
                    if (_phones[i] == null) continue;

                    int j = i;
                    while (j >= 0 && _phones[j + step] != null && _phones[j].Id > _phones[j + step].Id)
                    {
                        Swap(j, j + step);
                        j -= step;
                    }
                }
                step /= 2;
            }
            Array.Sort(_phones, (x, y) => x.Id.CompareTo(y.Id));
            UpdateAll();
        }

        /// <summary>
        /// Сортировка товаров по индексу
        /// </summary>
        public void SortByModel()
        {
            if (_phones == null) return;

            int step = _phones.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < _phones.Length - step; i++)
                {
                    if (_phones[i] == null) continue;

                    int j = i;
                    while (j >= 0 && _phones[j + step] != null && string.Compare(_phones[j].Model, _phones[j + step].Model) > 0)
                    {
                        Swap(j, j + step);
                        j -= step;
                    }
                }
                step /= 2;
            }
            UpdateAll();
        }

        /// <summary>
        /// Вывод товаров на витрине
        /// </summary>
        public override string ToString()
        {
            StringBuilder result = new($"ID витрины:\t{ShowcaseId}\nВместимость:\t{Capacity}\n\n");

            for (int i = 0; i < Capacity; i++)
                result.AppendLine($"Ячейка #{i}\n{(_phones[i] != null ? _phones[i] : "(пусто)\n")}\n");

            return result.ToString();
        }

        public T this[int index]
        {
            get
            {
                // Проверка допустимости индекса
                if (index < 0 || index >= Capacity) return null;

                // Возвращаем товар и очищаем позицию
                else
                {
                    T? phone = _phones[index];
                    _phones[index] = null;
                    return phone;
                }
            }

            set
            {
                // Проверка допустимости индекса
                if (index < 0 || index >= Capacity)
                    return;

                // Устанавливаем товар и обновляем его штрих-код
                _phones[index] = value;
                UpdateItemBarcode(value, index);
            }
        }
    }
}
