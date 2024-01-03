
static class ListExtension
{
    public static void AddToFront<T>(this List<T> list, T item) =>
     list.Insert(0, item);
}