using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IRAO.API.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
            this.ErrorMessages = new List<string>();
            this.Data = null;
        }
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
        public List<string> ErrorMessages { get; set; }
        public bool IsSuccess => this.StatusCode == HttpStatusCode.OK;
    }
    public class ResponseModel<TData>
    {
        public ResponseModel()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
            this.ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public TData Data { get; set; }
        public List<string> ErrorMessages { get; set; }
        public bool IsSuccess => this.StatusCode == HttpStatusCode.OK;
    }
}
