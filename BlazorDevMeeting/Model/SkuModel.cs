using System.Collections.Generic;

namespace BlazorDevMeeting.Model
{
    public class SkuModel
    {
        public int id { get; set; }
        public string cid { get; set; }
        public object ean13 { get; set; }
        public int? image { get; set; }
        public string name { get; set; }
        public int? brand { get; set; }
        public int? category { get; set; }
        public int? manufacturer { get; set; }
        public double? size_x_mm { get; set; }
        public double? size_y_mm { get; set; }
        public double? size_z_mm { get; set; }
    }

    public class SkuList
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<SkuModel> results { get; set; }
    }
}
