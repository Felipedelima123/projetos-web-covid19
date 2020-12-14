using ProjetosWebCovidApp.DAL;
using ProjetosWebCovidApp.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.IO;
using System.Web;
using System;
using System.Collections.Generic;

namespace ProjetosWebCovidApp.Controllers
{
    public class HomeController : Controller
    {
        private CovidTrackerContext db = new CovidTrackerContext();
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Username == _user.Username);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Username.Equals(username) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["Username"] = data.FirstOrDefault().Username;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["ID"] = data.FirstOrDefault().ID;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();
                        using (CsvReader csvReader =
                            new CsvReader(new StreamReader(stream), true))
                        {
                            csvTable.Load(csvReader);
                        }

                        foreach (DataRow row in csvTable.Rows)
                        {
                            foreach (DataColumn col in csvTable.Columns)
                            {
                                int i = 0;

                                string colData = row[i].ToString();
                                string colDataFormatted = colData.Replace("\"", "");

                                var stringArray = colDataFormatted.Split(',');

                                InfectedData data = new InfectedData()
                                {
                                    Idade = int.Parse(stringArray[0]),
                                    Sexo = stringArray[1],
                                    TpPaciente = stringArray[2],
                                    Bairro = stringArray[3],
                                    DataInclusao = getDatetimeFromString(stringArray[4]),
                                    DataNotificacao = getDatetimeFromString(stringArray[5]),
                                    DataRecuperacao = getDatetimeFromString(stringArray[6]),
                                    DataObito = getDatetimeFromString(stringArray[7]),
                                };

                                db.InfectedDatas.Add(data);
                                i++;
                            }
                        }

                        db.SaveChangesAsync();
                        return View(csvTable);
                    }
                    else
                    {
                        ModelState.AddModelError("Arquivo", "Formato do arquivo não é suportado");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("Arquivo", "Faça o Upload do arquivo");
                }
            }
            return View();
        }
        private DateTime getDatetimeFromString(string date)
        {
            try
            {
                return DateTime.Parse(date);
            } catch (FormatException)
            {
                return DateTime.MinValue;
            }
        }
    }
}