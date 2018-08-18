using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseApp.Model.Models;
using BaseApp.Service;
using BaseApp.Web.Models;

namespace BaseApp.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;


        public HomeController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var procat = _productCategoryService.GetAll().ToList();

            ProductCategory p = _productCategoryService.Add(new ProductCategory { Status = true, Name = "TheDTV 1", Alias = "aaa" });
            _productCategoryService.Save();
            var a = procat;
            return View();
            //var slideModel = _commonService.GetSlides();
            //var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            //var homeViewModel = new HomeViewModel();
            //homeViewModel.Slides = slideView;

            //var lastestProductModel = _productService.GetLastest(3);
            //var topSaleProductModel = _productService.GetHotProduct(3);
            //var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            //var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);
            //homeViewModel.LastestProducts = lastestProductViewModel;
            //homeViewModel.TopSaleProducts = topSaleProductViewModel;

            //try
            //{
            //    homeViewModel.Title = _commonService.GetSystemConfig(CommonConstants.HomeTitle).ValueString;
            //    homeViewModel.MetaKeyword = _commonService.GetSystemConfig(CommonConstants.HomeMetaKeyword).ValueString;
            //    homeViewModel.MetaDescription = _commonService.GetSystemConfig(CommonConstants.HomeMetaDescription).ValueString;
            //}
            //catch
            //{
               
            //}

            //return View(homeViewModel);
        }


        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 3600)]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}