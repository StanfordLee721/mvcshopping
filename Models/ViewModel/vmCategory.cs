using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvcshopping.Models.Tables;

namespace mvcshopping.Models.ViewModel
{// 在 Models/ViewModels/ProductListViewModel.cs 文件中
    public class vmCategoryList
    {
        public List<Category> Category { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}