using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Dynamic;
using TodoDetails_Api.Models;

namespace TodoDetails_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ToDoContext _context = null;
        
        public ToDoController (ToDoContext context)
        {
            _context = context;
        }


        [HttpGet]

        public ExpandoObject TodoDetailsGetting()
        {
            dynamic response = new ExpandoObject();
            try
            {
                var list = from db in _context.TitleDetails
                           select db;
                response.Data = list.ToList();

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }


        [HttpPost]

        public ExpandoObject saveTodoDetail(TitleDetail td)
        {
            dynamic response = new ExpandoObject();
            try
            {
              
                
                if (td.TitleDetails == "")
                {
                    response.Message = "Titel Can not be Empty ";
                }
                
                TitleDetail obj = new TitleDetail();
                obj.TitleDetails = td.TitleDetails;

                if (td.Status == 0 || td.Status == 1)
                {
                    obj.Status = td.Status;
                    _context.TitleDetails.Add(obj);
                    _context.SaveChanges();
                    response.message = "Succes";

                }
                else
                {
                    response.Message = "Enter Valid Status between 0 and 1 ";
                }
                
               
            }
            catch (Exception e)
            {
                response.Message = "Not save";
            }
            return response;
        }

        [HttpPut]
        public ExpandoObject EditTodo( TitleDetail tl)
        {
            dynamic response = new ExpandoObject();
            try
            {
                TitleDetail obj = _context.TitleDetails.Where(x => x.Titleid == tl.Titleid).First();
                obj.TitleDetails = tl.TitleDetails;
                obj.Status = tl.Status;
                _context.SaveChanges();
                response.Message = "Update Sucessfully";
            }
            catch (Exception e)
            {
                response.Message = "Not Update";

            }
            return response;

        }


        [HttpDelete]

        public ExpandoObject DeleteTodoDetails ( int id)
        {
            dynamic response = new ExpandoObject();
            try
            {
                TitleDetail obj = _context.TitleDetails.Where(x => x.Titleid == id).First();
                _context.TitleDetails.Remove(obj);
                _context.SaveChanges();
                response.Message = " Delet Successfully";



            }
            catch(Exception e)
            {
                response.Message = "Not Delete";

            }
            return response;
        }
    }
}
