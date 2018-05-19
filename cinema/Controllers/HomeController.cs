using cinema.Models;
using Service.Places;
using Service.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace cinema.Controllers
{
    public class HomeController : Controller
    {
        IPlacesService _placesService;
        public HomeController(IPlacesService placesService)
        {
            _placesService = placesService;
        }
        public ActionResult Index()
        {           
            return View();
        }

        public async Task<ActionResult> Init()
        {
            try
            {
                var dbPlaces = await _placesService.GetPlaces();
                List<Row> Rows = new List<Row>();
                for (int r = 1; r <= 40; r++)
                {
                    var _row = new Row { RowNumber = r };
                    for (int p = 1; p <= 20; p++)
                    {
                        var busy = dbPlaces.Where(w => w.PlaceNumber == p && w.Row == r).SingleOrDefault() != null ? true : false;
                        _row.Cols.Add(new Col { PlaceNumber = p, Busy = busy });
                    }
                    Rows.Add(_row);
                }
                return Json(new
                {
                    Success = true,
                    Message = Rows
                }, JsonRequestBehavior.AllowGet);
            }            
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public async Task<ActionResult> TakePlace(int RowNumber, int PlaceNumber)
        {
            try
            {
                var dbPlace = await _placesService.GetPlaceByRowAndPlaceNumber(RowNumber, PlaceNumber);
                if (dbPlace != null)
                    await _placesService.Remove(dbPlace);
                else
                {
                    var _place = new Place
                    {
                        PlaceNumber = PlaceNumber,
                        Row = RowNumber
                    };
                    await _placesService.SavePlace(_place);
                }

                return Json(new
                {
                    Success = true,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}