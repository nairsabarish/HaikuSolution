using Haiku.Interfaces;
using Haiku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Haiku.Controllers
{
    public class HaikuController : Controller
    {
        /// <summary>
        /// Parent View
        /// </summary>
        /// <returns></returns>
        public ActionResult ReviewMyHaiku()
        {
            #region Declarations
            ReviewHaikuViewModel l_haiku = new ReviewHaikuViewModel();
            HaikuModel l_HaikuText;
            List<HaikuModel> l_HaikuCollection;
            #endregion

            //If data exists in TempData then set it as a Model else create a blank object
            if(TempData["HikauData"]!=null)
            {
                l_haiku = (ReviewHaikuViewModel)TempData["HikauData"];
                l_haiku.IsSecondTabSelected = true;
            }
            else
            {
                l_HaikuText  = new HaikuModel();
                l_HaikuCollection = new List<HaikuModel>();
                l_haiku.HaikuText = l_HaikuText;
                l_haiku.l_HaikusReviewed = l_HaikuCollection;
                l_haiku.IsSecondTabSelected = false;
            }

            return View(l_haiku);
        }


        /// <summary>
        /// Post method for saving Haiku
        /// </summary>
        /// <param name="argReviewMyModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewMyHaiku(ReviewHaikuViewModel argReviewMyModel)
        {
            #region Declarations
            List<int> l_HikauLineCount;
            string l_HikauResult = string.Empty;
            HaikuModel l_HaikuModel;
            List<HaikuModel> l_HaikuReviewData;
            IHaikuContext IHikau = new HaikuContext.HaikuContext();
            #endregion

            try
            {
                if (ModelState.IsValid)
                {
                    if (argReviewMyModel != null)
                    {
                        if (argReviewMyModel.HaikuText != null && !string.IsNullOrEmpty(argReviewMyModel.HaikuText.HaikuText))
                        {
                            //Get Hikau lines into a string array
                            var l_HikauLines = argReviewMyModel.HaikuText.HaikuText.Split('/');

                            l_HikauLineCount = new List<int>();

                            //Get Syllable Count for each Hikau Line
                            foreach (var item in l_HikauLines)
                            {
                                l_HikauLineCount.Add(IHikau.GetSyllableCount(item));
                            }

                            l_HikauResult = IHikau.CheckIfHikauIsValid(l_HikauLineCount);

                            l_HaikuModel = new HaikuModel();
                            l_HaikuModel.SyllableCountFirstLine = l_HikauLineCount[0];
                            l_HaikuModel.SyllableCountSecondLine = l_HikauLineCount[1];
                            l_HaikuModel.SyllableCountThirdLine = l_HikauLineCount[2];
                            l_HaikuModel.HaikuText = argReviewMyModel.HaikuText.HaikuText;
                            l_HaikuModel.HaikuResult = l_HikauResult;

                            if (argReviewMyModel.l_HaikusReviewed != null)
                            {
                                argReviewMyModel.l_HaikusReviewed.Add(l_HaikuModel);
                            }
                            else
                            {
                                l_HaikuReviewData = new List<HaikuModel>();
                                l_HaikuReviewData.Add(l_HaikuModel);
                                argReviewMyModel.l_HaikusReviewed = l_HaikuReviewData;
                            }
                            TempData["HikauData"] = argReviewMyModel;
                        }
                    }
                }
                else
                {
                    return View(argReviewMyModel);
                }
            }
            catch(Exception)
            {

            }

            return RedirectToAction("ReviewMyHaiku");
        }
    }
}