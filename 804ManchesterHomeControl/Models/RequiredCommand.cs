//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _804ManchesterHomeControl.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequiredCommand
    {
        public int Id { get; set; }
        public int RoomActivityId { get; set; }
        public int DeviceCommandId { get; set; }
        public int Sequence { get; set; }
    
        public virtual DeviceCommand DeviceCommand { get; set; }
        public virtual RoomActivity RoomActivity { get; set; }
    }
}