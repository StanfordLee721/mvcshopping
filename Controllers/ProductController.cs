
using Microsoft.AspNetCore.Mvc;
//using mvcshopping.Models.MetaDataModel;
using mvcshopping.Models.ViewModel;
using mvcshopping.Models.Tables;


namespace mvcshopping.Controllers
{
    public class ProductController : Controller
    {
        private readonly dbEntities _context;
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration, dbEntities context)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index(int pageNumber = 1, int pageSize = 7)
        {
            int skip = (pageNumber - 1) * pageSize;

            var products = _context.Products
                .OrderBy(m => m.ProductNo)
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            int totalCount = _context.Products.Count();

            var model = new vmProductList
            {
                Products = products,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return View(model);
        }
        /// <summary>
        /// 產品資料新增
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return RedirectToAction("CreateEdit", "Product", new { area = "", id = 0 });
        }

        /// <summary>
        /// 產品資料修改
        /// </summary>
        /// <param name="id">要修改的Key值</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id = 0)
        {
            return RedirectToAction("CreateEdit", "Product", new { area = "", id = id });
        }

        // 建立/編輯畫面
        [HttpGet]
        public IActionResult CreateEdit(int id)
        {
            if (id == 0)
                return View(new Models.Tables.Products { ProductName = string.Empty, StockQuantity = 0 });
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // 建立/更新動作
        [HttpPost]
        public IActionResult CreateEdit(Products product)
        {
            if (!ModelState.IsValid)
                return View(product);

            if (product.ProductId == 0)
                _context.Products.Add(product);
            else
                _context.Products.Update(product);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // 刪除
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // [HttpGet]
        // public IActionResult Index()
        // {
        //     var products = _context.Products
        //         .OrderBy(m => m.ProductNo)
        //         .ToList();

        //     var model = new vmProductList
        //     {
        //         Products = products,
        //         CurrentPage = 1,
        //         PageSize = 5,
        //         TotalItems = products.Count,
        //         TotalPages = (int)Math.Ceiling(products.Count / 5.0)
        //     };

        //     return View(model);
        // }

        public IActionResult GetProducts(int pageNumber = 1, int pageSize = 5)
        {
            // 計算要跳過的記錄數
            int skip = (pageNumber - 1) * pageSize;

            // 修改查詢以支持分頁
            var products = _context.Products
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            // 獲取總記錄數用於前端分頁控件
            int totalCount = _context.Products.Count();

            return View(new vmProductList
            {
                Products = products,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            });
        }
    }
}
