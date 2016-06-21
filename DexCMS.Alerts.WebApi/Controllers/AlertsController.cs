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

        // GET api/Alerts
        public List<AlertApiModel> GetAlerts()
        {
            var items = repository.Items.Select(x => new AlertApiModel
            {
                AlertID = x.AlertID,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                AlertText = x.AlertText,
                DisplayOrder = x.DisplayOrder
            }).ToList();

            return items;
        }

        // GET api/Alerts/5
        [ResponseType(typeof(Alert))]
        public async Task<IHttpActionResult> GetAlert(int id)
        {
            Alert alert = await repository.RetrieveAsync(id);
            if (alert == null)
            {
                return NotFound();
            }

            AlertApiModel model = new AlertApiModel()
            {
                AlertID = alert.AlertID,
                StartDate = alert.StartDate,
                EndDate = alert.EndDate,
                AlertText = alert.AlertText,
                DisplayOrder = alert.DisplayOrder

            };

            return Ok(model);
        }

        // PUT api/Alerts/5
        public async Task<IHttpActionResult> PutAlert(int id, Alert alert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alert.AlertID)
            {
                return BadRequest();
            }

            await repository.UpdateAsync(alert, alert.AlertID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Alerts
        [ResponseType(typeof(Alert))]
        public async Task<IHttpActionResult> PostAlert(Alert alert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await repository.AddAsync(alert);

            return CreatedAtRoute("DefaultApi", new { id = alert.AlertID }, alert);
        }

        // DELETE api/Alerts/5
        [ResponseType(typeof(Alert))]
        public async Task<IHttpActionResult> DeleteAlert(int id)
        {
            Alert alert = await repository.RetrieveAsync(id);
            if (alert == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(alert);

            return Ok(alert);
        }
    }
}