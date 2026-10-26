namespace Product.Web.Utility
{
    public  class StaticDetails
    {
        public static string CouponAPIBase {  get; set; }
        public enum ApiTypes
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
