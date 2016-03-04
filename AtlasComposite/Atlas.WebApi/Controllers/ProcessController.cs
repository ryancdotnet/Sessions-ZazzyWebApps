using Atlas.Model;
using Atlas.WebApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Atlas.WebApi.Controllers
{
    [RoutePrefix("Processes")]
    public class ProcessController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage result = null;

            try
            {
                result = Request.CreateResponse<List<Process>>(TerribleStaticModelContext.Processes);
            }
            catch (Exception ex)
            {
                //Log the error
                //TODO: log it!

                //Note the error in response
                result = Request.CreateResponse(HttpStatusCode.InternalServerError);

                //NOTE: Probably a bad idea to return raw exception messages to external clients
                result.ReasonPhrase = ex.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("{processId}")]
        public HttpResponseMessage GetById(int processId)
        {
            HttpResponseMessage result = null;

            try
            {
                result = Request.CreateResponse<Process>(TerribleStaticModelContext.Processes.SingleOrDefault(t => t.ProcessId == processId));
            }
            catch (Exception ex)
            {
                //Log the error
                //TODO: log it!

                //Note the error in response
                result = Request.CreateResponse(HttpStatusCode.InternalServerError);

                //NOTE: Probably a bad idea to return raw exception messages to external clients
                result.ReasonPhrase = ex.Message;
            }

            return result;
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateNew([FromBody] Process process)
        {
            HttpResponseMessage result = null;

            try
            {
                //Check if already exist
                if (TerribleStaticModelContext.Processes.Any(t => t.ProcessId == process.ProcessId))
                {
                    result = Request.CreateResponse(HttpStatusCode.Conflict);
                    return result;
                }

                TerribleStaticModelContext.Processes.Add(process);

                result = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                //Log the error
                //TODO: log it!

                //Note the error in response
                result = Request.CreateResponse(HttpStatusCode.InternalServerError);

                //NOTE: Probably a bad idea to return raw exception messages to external clients
                result.ReasonPhrase = ex.Message;
            }

            return result;
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage DeleteAll()
        {
            HttpResponseMessage result = null;

            try
            {
                TerribleStaticModelContext.Processes.Clear();

                result = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                //Log the error
                //TODO: log it!

                //Note the error in response
                result = Request.CreateResponse(HttpStatusCode.InternalServerError);

                //NOTE: Probably a bad idea to return raw exception messages to external clients
                result.ReasonPhrase = ex.Message;
            }

            return result;
        }
    


        [HttpPost]
        [Route("{processId}")]
        public HttpResponseMessage Update(int processId, [FromBody] Process process)
        {
            HttpResponseMessage result = null;

            try
            {
                //Get existing
                Process existing = TerribleStaticModelContext.Processes.Single(t => t.ProcessId == processId);

                //Ensure it exist
                if (existing == null)
                {
                    result = Request.CreateResponse(HttpStatusCode.NotFound);
                    return result;
                }
                
                //Update
                existing.StartDate = process.StartDate;
                existing.EndDate = process.EndDate;
                existing.ProcessStatus = process.ProcessStatus;

                //Save
                //NOTE: Because objects are in-mem, no save needed.

                result = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                //Log the error
                //TODO: log it!

                //Note the error in response
                result = Request.CreateResponse(HttpStatusCode.InternalServerError);

                //NOTE: Probably a bad idea to return raw exception messages to external clients
                result.ReasonPhrase = ex.Message;
            }

            return result;
        }
    }
}