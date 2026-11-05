using static G_NET97_LINQ_Assignment_2.Source;

namespace G_NET97_LINQ_Assignment_2
{
    public static class ClassMethods
    {
        #region Question01 
        //
        public static void ToThreeExpensiveProducts()
        {
            var Result = ProductList.OrderByDescending(p => p.UnitPrice).Take(3);
            foreach (var product in Result)
            {
                Console.WriteLine($"Product: {product.ProductName}, Price: {product.UnitPrice}");
            }
        }
        #endregion

        #region Question02
        //
        public static void ProductsPaging()
        {
            int PageNumber = 2,
            PageSize = 5;
            var Result = ProductList.Skip((PageNumber - 1) * PageSize).Take(PageSize);
            foreach (var product in Result)
            {
                Console.WriteLine($"Product: {product.ProductID}, Category: {product.ProductName}");
            }
        }
        #endregion

        #region Question03
        //
        public static void ProductsCheaperThan25()
        {
            var Result = ProductList.GroupBy(p => p.Category)
                .Select(g => new { CategoryID = g.Key, Count = g.Count() });
            foreach (var item in Result)
            {
                Console.WriteLine($"Category: {item.CategoryID}, Count: {item.Count}");
            }
        }
        #endregion

        #region Question04
        //
        public static void AllSeaFoodInSotck()
        {

            bool result = ProductList.Where(p => p.Category == "Seafood").All(p => p.UnitsInStock > 0);

            Console.WriteLine(result);

        }
        #endregion

        #region Question05
        //
        public static void IdsContainsNine()
        {
            int[] ids = { 3, 9, 13, 18 };
            Console.WriteLine(ids.Contains(9));
        }
        #endregion

        #region Question06
        //
        public static void GroupByCategoryWithCount()
        {            var groups = ProductList.GroupBy(p => p.Category);

            foreach (var go in groups)
            {
                Console.WriteLine($"{go.Key} ({go.Count()} products)");
                foreach (var po in go )
                    Console.WriteLine($"   {po.ProductName}");
            }

        }
        #endregion

        #region Question07
        //
        public static void GroupByCategoryProductNames()
        {
            var result = ProductList.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                Names = g.Select(p => p.ProductName)
            });

            foreach (var item in result)
            {
                Console.WriteLine(item.Category);
                foreach (var name in item.Names)
                    Console.WriteLine($"   {name}");
            }

        }
        #endregion

        #region Question08
        //
        public static void CategoriesWithMoreThanThreeProducts()
        {
            var result = ProductList.GroupBy(p => p.Category).Where(g => g.Count() > 3).Select(g => g.Key);
            foreach (var category in result)
                Console.WriteLine(category);

        }
        #endregion

        #region Question09
        //
        public static void CustomersByCountryQuerySyntax()
        {
            var result = from c in CustomerList
                         group c by c.Country into g
                         select new
                         {
                             Country = g.Key,
                             Count = g.Count(),
                             TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
                         };

            foreach (var item in result)
                Console.WriteLine($"{item.Country} | Count: {item.Count} | TotalOrderValue: {item.TotalOrderValue:C}");
        }

        #endregion

        #region Question10
            //
        public static void TotalUnitsInStock()
        {
            int total = ProductList.Sum(p => p.UnitsInStock);
            Console.WriteLine(total);

        }
        #endregion

        #region Question11
        //
        public static void CheapestAndMostExpensive()
        {
            var cheapest = ProductList.MinBy(p => p.UnitPrice);
            var mostExpensive = ProductList.MaxBy(p => p.UnitPrice);

            Console.WriteLine($"Cheapest: {cheapest:C}");
            Console.WriteLine($"Most expensive: {mostExpensive:C}");

        }
        #endregion

        #region Question12
        //
        public static void DistinctCategories()
        {
            var result = ProductList
                .Select(p => p.Category)
                .Distinct();

            foreach (var category in result)
                Console.WriteLine(category);

        }
        #endregion

        #region Question13
        //
        public static void SetAExceptSetB()
        {
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var result = setA.Except(setB);
            Console.WriteLine(string.Join(", ", result));
        }
        #endregion

        #region Question14
        public static void CountriesExceptCaseInsensitive()
        {
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            var result = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(string.Join(", ", result));
        }
        #endregion

        #region Question15
        public static void ProductsDictionary()
        {
            Dictionary<int, Product> dict = ProductList.ToDictionary(p => p.ProductID);

            if (dict.TryGetValue(18, out Product product))
                Console.WriteLine($"{product.ProductID}: {product.ProductName} - {product.UnitPrice:C}");
            else
                Console.WriteLine("Product 18 not found");
        }
        #endregion

        #region Question16
        public static void FirstProductOver50()
        {
            var product = ProductList.First(p => p.UnitPrice > 50);
            Console.WriteLine($"{product.ProductName} - {product.UnitPrice:C}");
        }
        #endregion

        #region Question17
        public static void FirstProductOver500OrDefault()
        {
            var product = ProductList.FirstOrDefault(p => p.UnitPrice > 500);
            Console.WriteLine(product == null
                ? "null (no product found)"
                : $"{product.ProductName} - {product.UnitPrice:C}");
        }
        #endregion

        #region Question18
        public static void MultiplicationTableOf7()
        {
            var result = Enumerable.Range(1, 10).Select(i => $"7 x {i} = {7 * i}");

            foreach (var line in result)
                Console.WriteLine(line);
        }
        #endregion

        #region Question19
        public static void EvenNumbers1To30()
        {
            var result = Enumerable.Range(1, 30).Where(n => n % 2 == 0);
            Console.WriteLine(string.Join(", ", result));
        }
        #endregion

        #region Question20
        public static void ConcatProductAndCustomerNames()
        {
            var productNames = ProductList.Take(3).Select(p => p.ProductName);
            var companyNames = CustomerList.Take(3).Select(c => c.CustomerName);

            var result = productNames.Concat(companyNames);

            foreach (var name in result)
                Console.WriteLine(name);
        }
        #endregion

        #region Question21
        public static void ZipProductsWithCustomers()
        {
            var result = ProductList.Zip(CustomerList,
                (p, c) => $"{p.ProductName} sold to {c.CustomerName}");

            foreach (var line in result)
                Console.WriteLine(line);
        }
        #endregion
    }
}
