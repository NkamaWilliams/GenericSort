using Assgn;
namespace SortTest
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        //Test to see if sort class works on primitive datatypes e.g int
        public void TestMethod1()
        {
            int[] list = {1, -2, 4, 9, 0, 6, 3};
            int[] sortedlist = Sort<int>.MergeSort(list);
            bool isTrue = sortedlist.SequenceEqual(new int[] { -2, 0, 1, 3, 4, 6, 9 });
            Console.WriteLine(isTrue);
            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        //Test to see if sort class works on user classes e.g. Product
        public void TestMethod2()
        {
            Product[] products = { new Product("Rice", 200), new Product("Beans", 500), new Product("Cake", 1000)};
            Product[] sortedProducts = Sort<Product>.MergeSort(products);
            Product[] compareProducts = { new Product("Beans", 500), new Product("Cake", 1000), new Product("Rice", 200) };
            bool isTrue = true;
            for (int i = 0; i< products.Length; i++)
            {
                isTrue = sortedProducts[i].name == compareProducts[i].name;
            }
            Assert.IsTrue(isTrue);
        }
    }
}