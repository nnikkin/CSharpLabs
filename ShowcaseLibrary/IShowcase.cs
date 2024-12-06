using ProductLibrary;

namespace ShowcaseLibrary
{
    public interface IShowcase<T> where T : class, IProduct
    {
        T this[int index] { get; set; }

        int Capacity { get; set; }
        int ShowcaseId { get; set; }

        void Add(int index, T phone);
        void Add(T phone);
        void Delete();
        void Delete(int index);
        void ReplaceItem(int index, T phone);
        int Search(int id);
        int Search(string name);
        void SortById();
        void SortByModel();
        void Swap(int index1, int index2);
    }
}