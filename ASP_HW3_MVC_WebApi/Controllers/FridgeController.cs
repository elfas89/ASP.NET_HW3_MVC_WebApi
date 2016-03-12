using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Homework2;

//1. Разработайте набор необходимых Web-служб, которые позволяют манипулировать компонентом "умного дома" с расширенными возможностями.
//2. НапишитеHTML-страницу, которая позволяет манипулировать данным компонентом при помощи разработанных Web-служб. 
//Необходимо использовать технологию AJAX для взаимодействия HTML-страницы и Web-служб.


namespace ASP_HW3_MVC_WebApi.Controllers
{
    public class FridgeController : ApiController
    {

        //берем коллекцию из сессии
        IDictionary<string, Component> componentList = (Dictionary<string, Component>)System.Web.HttpContext.Current.Session["Components"];


        // GET: api/Fridge
        public IEnumerable<string> Get()
        {
            return new string[] { "холод1", "холод2" };
        }


        public string Get(string name)
        {
           Fridge f = new Fridge(name);
           return " GET ввели: " + name + "; " + f.Info();
        }


        // POST: api/Fridge
        public string Post([FromBody]string name)
        {
            Fridge f = new Fridge(name);
            return "POST: " + name + "; " + ((Fridge)componentList[name]).Info();
        }

        // PUT: api/Fridge/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // PUT: api/Fridge/button/name
        [Route("api/Fridge/{button}/{name}")]
        public string Put(string button, string name)
        {
            //IDictionary<string, Component> componentList = (Dictionary<string, Component>)System.Web.HttpContext.Current.Session["Components"];
             //System.Web.HttpContext.Current.Session["Components"]
            switch (button)
            {
                case "on":
                    ((Fridge)componentList[name]).PowerOn();
                    break;
                case "off":
                    ((Fridge)componentList[name]).PowerOff();
                    break;
                case "open":
                    ((Fridge)componentList[name]).Open();
                    break;
                case "close":
                    ((Fridge)componentList[name]).Close();
                    break;
            }
            return ((Fridge)componentList[name]).Info();
        }

        [Route("api/Fridge/{button}/{name}/{valueBox}")]
        public string Put(string button, string name, string valueBox)
        {
            switch (valueBox)
            {
                case ("normal"):
                    ((Fridge)componentList[name]).Normal();
                    break;
                case ("north"):
                    ((Fridge)componentList[name]).North();
                    break;
                case ("south"):
                    ((Fridge)componentList[name]).South();
                    break;
                default:
                    break;
            }
            return ((Fridge)componentList[name]).Info();
        }

        // DELETE: api/Fridge/5
        [Route("api/Fridge/{name}")]
        public void Delete(string name)
        {
            componentList.Remove(name);
        }
    }
}
