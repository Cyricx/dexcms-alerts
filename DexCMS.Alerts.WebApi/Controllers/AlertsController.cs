using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Alerts.Interfaces;
using DexCMS.Alerts.Models;
using DexCMS.Alerts.WebApi.ApiModels;

namespace DexCMS.Alerts.WebApi.Controllers
{
    [Authorize(Roles="Admin")]
    public class AlertsController : ApiController
    {
        private IAlertRepository repository;

        public AlertsController(IAlertRepository repo)
        {
            repository = repo;
        }

        [ResponseType(typeof(AlertApiModel))]
        public List<AlertApiModel> GetAlerts()
        {
            return AlertApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(AlertApiModel))]
        public async Task<IHttpActionResult> GetAlert(int id)
        {
            Alert alert = await repository.RetrieveAsync(id);
            if (alert == null)
            {
                return NotFound();
            }

            return Ok(AlertApiModel.MapForClient(alert));
        }

        public async Task<IHttpActionResult> PutAlert(int id, AlertApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.AlertID)
            {
                return BadRequest();
            }
            Alert alert = await repository.RetrieveAsync(id);
            AlertApiModel.MapForServer(apiModel, alert);

            await repository.UpdateAsync(alert, alert.AlertID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(AlertApiModel))]
        public async Task<IHttpActionResult> PostAlert(AlertApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Alert alert = new Alert();
            AlertApiModel.MapForServer(apiModel, alert);

            await repository.AddAsync(alert);

            return CreatedAtRoute("DefaultApi", new { id = alert.AlertID }, AlertApiModel.MapForClient(alert));
        }

        [ResponseType(typeof(AlertApiModel))]
        public async Task<IHttpActionResult> DeleteAlert(int id)
        {
            Alert alert = await repository.RetrieveAsync(id);
            if (alert == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(alert);

            return Ok(AlertApiModel.MapForClient(alert));
        }
    }
}