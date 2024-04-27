using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Career
{
    public class LifeAtNobelEnergyComponentViewModel
    {
        public LifeAtNobelEnergyComponentViewModel()
        {
            LifeAtNobelEnergies = new List<LifeAtNobelEnergy>();
            LifeAtNobelEnergyPdfs = new List<LifeAtNobelEnergyPdf>();
        }

        public LifeAtNobelEnergy LifeAtNobelEnergy { get; set; }
        public List<LifeAtNobelEnergy> LifeAtNobelEnergies { get; set; }
        public List<LifeAtNobelEnergyPdf> LifeAtNobelEnergyPdfs { get; set; }
    }
}
