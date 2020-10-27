using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTBIAsset.Shared
{
    public class Stock
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string BarCode { get; set; }

        [Range(1, 9999, ErrorMessage = "Please select Location")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Required]
        public string Fixed_Asset_Code { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Fixed_Asset_Name { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Specification { get; set; }

        [StringLength(20)]
        public string Uom { get; set; }

        public double? Cost { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Serial { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PO_Number { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DR_Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date_Acquired { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Assigned { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public Stock()
        {

        }
        public Stock(int id, string barcode,int locId,string asset_code,
            string asset_name,string specs,string uom,double? cost,string serial,
            string po_number,string dr_number,DateTime? date_aquired,string assigned,string status,string remarks)
        {
            this.Id = id;
            this.BarCode = barcode;
            this.LocationId = locId;
            this.Fixed_Asset_Code = asset_code;
            this.Fixed_Asset_Name = asset_name;
            this.Specification = specs;
            this.Uom = uom;
            this.Cost = cost;
            this.Serial = serial;
            this.PO_Number = po_number;
            this.DR_Number = dr_number;
            this.Date_Acquired = date_aquired;
            this.Assigned = assigned;
            this.Status = status;
            this.Remarks = remarks;
        }
    }
}
