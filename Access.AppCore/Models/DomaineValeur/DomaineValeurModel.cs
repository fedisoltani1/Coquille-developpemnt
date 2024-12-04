namespace Access.AppCore.Models.DomaineValeur
{
    public class DomaineValeurModel
    {
        public DomaineValeurModel()
        {
            Elements = [];
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string DescriptionCourte { get; set; }

        public string DescriptionComplete { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public List<DomaineValeurElementModel> Elements { get; set; }
    }
}
