
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
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductController(IConfiguration configuration, dbEntities context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
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
            // if (id == 0)
            //     return View(new Models.Tables.Products { ProductName = string.Empty, StockQuantity = 0 });
            if (id == 0)
            {
                var newProduct = new Products
                {
                    ProductName = string.Empty,
                    StockQuantity = 0
                };
                return View(newProduct);
            }

            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // 建立/更新動作
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(Products product, IFormFile? ImageFile)
        {
            if (!ModelState.IsValid)
                return View(product);

            try
            {
                // 處理圖片上傳
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // 如果是編輯模式且有舊圖片，先刪除舊圖片
                    if (product.ProductId > 0 && !string.IsNullOrEmpty(product.ImageUrl))
                    {
                        DeleteOldImage(product.ImageUrl);
                    }

                    // 儲存新圖片
                    product.ImageUrl = await SaveUploadedImage(ImageFile);
                }

                if (product.ProductId == 0)
                {
                    _context.Products.Add(product);
                    TempData["Success"] = "商品新增成功！";
                }
                else
                {
                    _context.Products.Update(product);
                    TempData["Success"] = "商品更新成功！";
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"操作失敗：{ex.Message}");
                return View(product);
            }
        }

        // 刪除
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            // 刪除關聯的圖片檔案
            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                DeleteOldImage(product.ImageUrl);
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            TempData["Success"] = "商品刪除成功！";
            return RedirectToAction("Index");
        }

        public IActionResult GetProducts(int pageNumber = 1, int pageSize = 7)
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
        //還沒建立viewindex、沒建立顯示Category的view
        [HttpGet]
        public IActionResult CategoryIndex(int pageNumber = 1, int pageSize = 7)
        {
            int skip = (pageNumber - 1) * pageSize;

            var category = _context.Category
                .OrderBy(m => m.CategoryId)
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            int totalCount = _context.Category.Count();

            var model = new vmCategoryList
            {
                Category = category,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult CategoryCreateEdit(int id)
        {
            if (id == 0)
                return View(new Models.Tables.Category { CategoryName = string.Empty });
            var category = _context.Category.Find(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // 建立/更新動作
        [HttpPost]
        public IActionResult CategoryCreateEdit(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            if (category.CategoryId == 0)
                _context.Category.Add(category);
            else
                _context.Category.Update(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        // 刪除
        public IActionResult CategoryDelete(int id)
        {
            var category = _context.Category.Find(id);
            if (category == null)
                return NotFound();

            _context.Category.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }

        /// <summary>
        /// 圖片上傳頁面
        /// </summary>
        /// <param name="id">產品ID</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PhotoUpload(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                TempData["Error"] = "找不到指定的產品";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        /// <summary>
        /// 處理圖片上傳
        /// </summary>
        /// <param name="id">產品ID</param>
        /// <param name="file">上傳的檔案</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PhotoUpload(int id, IFormFile file)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                TempData["Error"] = "找不到指定的產品";
                return RedirectToAction("Index");
            }

            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "請選擇要上傳的圖片檔案";
                return View(product);
            }

            try
            {
                // 如果之前有圖片，先刪除舊圖片
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    DeleteOldImage(product.ImageUrl);
                }

                // 儲存新圖片並更新產品資料
                product.ImageUrl = await SaveUploadedImage(file);
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                TempData["Message"] = "圖片上傳成功！";
                return RedirectToAction("PhotoUpload", new { id = product.ProductId });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"上傳失敗：{ex.Message}";
                return View(product);
            }
        }

        #region 私有方法 - 圖片處理

        /// <summary>
        /// 儲存上傳的圖片
        /// </summary>
        /// <param name="imageFile">上傳的圖片檔案</param>
        /// <returns>圖片相對路徑</returns>
        private async Task<string> SaveUploadedImage(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            // 檢查檔案類型
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new InvalidOperationException("只允許上傳 JPG、PNG、GIF 格式的圖片");
            }

            // 檢查檔案大小 (5MB)
            if (imageFile.Length > 5 * 1024 * 1024)
            {
                throw new InvalidOperationException("圖片檔案大小不能超過 5MB");
            }

            // 建立上傳目錄
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "products");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // 產生唯一檔名
            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // 儲存檔案
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            // 回傳相對路徑
            return "/uploads/products/" + uniqueFileName;
        }

        private void DeleteOldImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return;

            try
            {
                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            catch (Exception ex)
            {
                // 記錄錯誤但不影響主要流程
                // 你可以加入 Logger 來記錄這個錯誤
                Console.WriteLine($"刪除圖片失敗: {ex.Message}");
            }
        }

        #endregion
    }
}
