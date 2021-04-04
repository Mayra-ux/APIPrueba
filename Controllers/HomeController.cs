using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoAplicacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MiPagina()
        {
            ViewBag.Message = "Pagina Principal";

            return View();
        }
        //getUsuarios
        [HttpGet]
        public JsonResult getUsuarios()
        {
            try
            {


                using (Models.BDPrueba db = new Models.BDPrueba())
                {

                    var oUsuarios = (from m in db.Usuarios select m).ToList();

                    return Json(oUsuarios, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) {

                return Json(e.Message, JsonRequestBehavior.AllowGet);

            }
        }


        //get user by id
        [HttpGet]
        public JsonResult getUserId(int idUsuario)
        {
            try
            {


                using (Models.BDPrueba db = new Models.BDPrueba())
                {

                    var oUsuarios = (from m in db.Usuarios where m.IdUsuario == idUsuario select m).ToList();

                    return Json(oUsuarios, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

                return Json(e.Message, JsonRequestBehavior.AllowGet);

            }
        }

        //save user
        [HttpPost]
        public JsonResult saveUser (Models.Usuarios usuarios)
        {
            try
            {


                using (Models.BDPrueba db = new Models.BDPrueba())
                {

                    var oUsuarios = new Models.Usuarios
                    {
                        ApellidoMaterno = usuarios.ApellidoMaterno,
                        ApellidoPaterno = usuarios.ApellidoPaterno,
                        Celular = usuarios.Celular,
                        Curp = usuarios.Curp,
                        RFC = usuarios.RFC,
                        Email = usuarios.Email,
                        IdUsuario = usuarios.IdUsuario,
                        Nombre = usuarios.Nombre,
                    };

                    db.Usuarios.Add(oUsuarios);
                    db.SaveChanges();

                    return Json(oUsuarios, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

                return Json(e.Message, JsonRequestBehavior.AllowGet);

            }
        }



        //update user
        [HttpPost]
        public JsonResult updateUser(Models.Usuarios usuarios)
        {
            try
            {


                using (Models.BDPrueba db = new Models.BDPrueba())
                {
                    var oUser = db.Usuarios.FirstOrDefault(x=> x.IdUsuario == usuarios.IdUsuario);

                    if (oUser != null)
                    {


                        oUser.ApellidoMaterno = usuarios.ApellidoMaterno;
                        oUser.ApellidoPaterno = usuarios.ApellidoPaterno;
                        oUser.Celular = usuarios.Celular;
                        oUser.Curp = usuarios.Curp;
                        oUser.RFC = usuarios.RFC;
                        oUser.Email = usuarios.Email;
                        oUser.IdUsuario = usuarios.IdUsuario;
                        oUser.Nombre = usuarios.Nombre;



                        db.SaveChanges();

                        return Json(oUser, JsonRequestBehavior.AllowGet);
                    }

                    else {
                        return Json("No encontrado", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception e)
            {

                return Json(e.Message, JsonRequestBehavior.AllowGet);

            }
        }

        //delete user
        [HttpPost]
        public JsonResult DeleteUser (int IdUser)
        {
            try
            {


                using (Models.BDPrueba db = new Models.BDPrueba())
                {
                    var oUser = db.Usuarios.FirstOrDefault(x => x.IdUsuario == IdUser);

                    if (oUser != null)
                    {


                        db.Usuarios.Remove(oUser);


                        db.SaveChanges();

                        return Json(oUser, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        return Json("No encontrado", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception e)
            {

                return Json(e.Message, JsonRequestBehavior.AllowGet);

            }
        }





    }
 }