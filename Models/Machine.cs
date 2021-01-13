using System;
using System.ComponentModel.DataAnnotations;

namespace Mock.RestApi.Models
{
    public enum MachineType { iNspire, eSmart, eVision, eFlow, eTower }
    public class Machine : Base
    {
        [Required, RegularExpression("^([A-Z|0-9]{5}-?){5}$")]
        public string HardwareKey { get; set; }
        [Required, RegularExpression("^([A-Z|0-9]{5}-?){5}$")]
        public string LicenseKey { get; set; }
        public MachineType MachineType { get; set; }
        public DateTime ProductionDate { get; set; }
        //Może być nullem, maszyna może (jeszcze) nie mieć właścicela
        public Customer Customer { get; set; }
    }
}
