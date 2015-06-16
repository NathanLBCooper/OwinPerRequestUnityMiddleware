using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OwinPerRequestExample.Models;
using OwinPerRequestExample.Objects;

using WebGrease.Css.Extensions;

namespace OwinPerRequestExample.Controllers
{
    public class HomeController : Controller
    {
        private List<ObjectInfoModel> model;
        private ISameInRequestDisposible[] disposibles;

        public HomeController(
            IAlwaysTheSame same,
            ISameInARequest req0,
            ISameInARequest req1,
            IAlwaysDifferent diff0,
            IAlwaysDifferent diff1,
            ISameInRequestDisposible reqDis0,
            ISameInRequestDisposible reqDis1)
        {
            var objects = new object[] { same, req0, req1, diff0, diff1, reqDis0, reqDis1 };

            this.model = objects.Select(x => new ObjectInfoModel { HashCode = x.GetHashCode().ToString(), ObjectName = x.GetType().Name, Object = x}).ToList();
            this.disposibles = new [] { reqDis0, reqDis1};

        }

        public ActionResult Index()
        {
            this.model.ForEach( x => { var refable = x.Object as IReferenceCounting;
                                    if (refable != null)
                                    {
                                        x.Undisposed = refable.NumberOfUndisposed;
                                    } });

            
            this.disposibles.ForEach( x => x.CheckObjectIsNotDisposedWhenWeNeedIt());

            return View(this.model);
        }
    }
}