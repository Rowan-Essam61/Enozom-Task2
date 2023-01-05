namespace Enozom_task.Models
{
    public class CountryHoliday
    {
        public int Id { get; set; }
        
        [ForeignKey("countries")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

        [ForeignKey("Days")]
        public int HolidayID { get; set; }
        public virtual Day Day { get; set; }
    }
}
